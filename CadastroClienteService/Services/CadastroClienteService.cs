using CadastroClienteService.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;


namespace CadastroClienteService
{
    public class CadastroClienteService : CadastroCliente.CadastroClienteBase
    {
        private readonly ClienteContext _context;
        private readonly ILogger<CadastroClienteService> _logger;

        public CadastroClienteService(ClienteContext context, ILogger<CadastroClienteService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<ClienteMessage> CriarCliente(CriarClienteRequest request, ServerCallContext context)
        {
            var cliente = new Cliente
            {
                Nome = request.Cliente.Nome,
                Cargo = request.Cliente.Cargo,
                Idade = request.Cliente.Idade
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return new ClienteMessage
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cargo = cliente.Cargo,
                Idade = cliente.Idade
            };
        }

        public override async Task<ClienteMessage> ObterCliente(ObterClienteRequest request, ServerCallContext context)
        {
            var cliente = await _context.Clientes.FindAsync(request.Id);

            if (cliente == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Cliente com ID={request.Id} não encontrado"));
            }

            return new ClienteMessage
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cargo = cliente.Cargo,
                Idade = cliente.Idade
            };
        }

        public override async Task<ClienteMessage> AtualizarCliente(AtualizarClienteRequest request, ServerCallContext context)
        {
            var cliente = await _context.Clientes.FindAsync(request.Cliente.Id);

            if (cliente == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Cliente com ID={request.Cliente.Id} não encontrado"));
            }

            cliente.Nome = request.Cliente.Nome;
            cliente.Cargo = request.Cliente.Cargo;
            cliente.Idade = request.Cliente.Idade;

            await _context.SaveChangesAsync();

            return new ClienteMessage
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cargo = cliente.Cargo,
                Idade = cliente.Idade
            };
        }

        public override async Task<ClienteMessage> DeletarCliente(DeletarClienteRequest request, ServerCallContext context)
        {
            var cliente = await _context.Clientes.FindAsync(request.Id);

            if (cliente == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Cliente com ID={request.Id} não encontrado"));
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return new ClienteMessage
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cargo = cliente.Cargo,
                Idade = cliente.Idade
            };
        }

        public override async Task<ListarClientesResponse> ListarClientes(ListarClientesRequest request, ServerCallContext context)
        {
            var clientes = await _context.Clientes.Select(c => new ClienteMessage
            {
                Id = c.Id,
                Nome = c.Nome,
                Cargo = c.Cargo,
                Idade = c.Idade
            }).ToListAsync();

            return new ListarClientesResponse
            {
                Clientes = { clientes }
            };
        }
    }
}
