using Grpc.Net.Client;
using CadastroClienteClient;
using System;

namespace CadastroClienteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5260");
            var client = new CadastroCliente.CadastroClienteClient(channel);

            
            var listarReply = client.ListarClientes(new ListarClientesRequest { });
            // Listar clientes
            Console.WriteLine("Listar Response: " + listarReply.Clientes); 

            // Criar um novo cliente
            var criarReply = client.CriarCliente(new CriarClienteRequest { Cliente = new ClienteMessage { Nome = "Marcelo", Cargo = "Desenvolvedor", Idade = 50 } });
            Console.WriteLine($"Criar response: Id = {criarReply.Id}, Nome = {criarReply.Nome}, Cargo = {criarReply.Cargo}, Idade = {criarReply.Idade}");

            // Listar clientes
            Console.WriteLine("Listar Response: " + listarReply.Clientes); 

            // Obter informações do cliente
            var obterReply = client.ObterCliente(new ObterClienteRequest { Id = criarReply.Id });
            Console.WriteLine($"Obter response: Id = {obterReply.Id}, Nome = {obterReply.Nome}, Cargo = {obterReply.Cargo}, Idade = {obterReply.Idade}");

            // Atualizar informações do cliente
            var atualizarReply = client.AtualizarCliente(new AtualizarClienteRequest { Cliente = new ClienteMessage { Id = criarReply.Id, Nome = "Marcelo", Cargo = "Desenvolvedor Sênior", Idade = 51 } });
            Console.WriteLine($"Atualizar response: Id = {atualizarReply.Id}, Nome = {atualizarReply.Nome}, Cargo = {atualizarReply.Cargo}, Idade = {atualizarReply.Idade}");

            // Obter informações do cliente atualizado
            var obterReplyAtualizado = client.ObterCliente(new ObterClienteRequest { Id = criarReply.Id });
            Console.WriteLine($"Obter response atualizado: Id = {obterReplyAtualizado.Id}, Nome = {obterReplyAtualizado.Nome}, Cargo = {obterReplyAtualizado.Cargo}, Idade = {obterReplyAtualizado.Idade}");

            // Listar clientes
            Console.WriteLine("Listar Response: " + listarReply.Clientes); 

            // Criar um novo cliente
            var criarReplyNovo = client.CriarCliente(new CriarClienteRequest { Cliente = new ClienteMessage { Nome = "Marcelo 2", Cargo = "Desenvolvedor", Idade = 30 } });
            Console.WriteLine($"Criar response: Id = {criarReplyNovo.Id}, Nome = {criarReplyNovo.Nome}, Cargo = {criarReplyNovo.Cargo}, Idade = {criarReplyNovo.Idade}");

            // Listar clientes
            Console.WriteLine("Listar Response: " + listarReply.Clientes); 

            // Deletar cliente
            var deletarReply = client.DeletarCliente(new DeletarClienteRequest { Id = criarReply.Id });
            Console.WriteLine($"Deletar response: Id = {deletarReply.Id}, Nome = {deletarReply.Nome}, Cargo = {deletarReply.Cargo}, Idade = {deletarReply.Idade}");
            
            // Listar clientes
            Console.WriteLine("Listar Response: " + listarReply.Clientes); 
        }
    }
}
