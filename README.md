## This is a work using C# and gRPC request for the DM113 discipline.

**Operational System:**

- *Kali Linux 2023.3*

---

**Technologies:**

- *Visual Studio Code 2023 1.82.2 (optional)*
- *.NET SDK 8.0.200 (mandatory)*
- *Insomnia 8.6.1 (optional)*

---

**Payload:**

In the main folder where you cloned the project, there is a file called `Insomnia_dm113.json` that you can use to import to your preferred API platform or tool. I've used Insomnia for this project, but you can use any other since it supports gRPC calls, so you will have all the endpoints ready and configured to use and test the APIs.

---

**How to run:**

1. Clone the repository into a single folder to not have path problems. Ex.: `'C:\dm113'` or `'/home/dm113'`

2. Ways to run:

	- First way to run: Go to the folder where you cloned the project:
      -  a) You will find two folders with the names: `CadastroClienteService` and `CadastroClienteClient`.
      -  b) In the folder `CadastroClienteService` run the below command to start the gRPC service:
          -  `dotnet run`
      - c) Open another terminal and go to the folder `CadastroClienteClient` and run the below command to execute the client application that will perform some request tasks for the service and return the results.
          - `dotnet run`

	- Second way to run: Repeat the step 1, letters **"a"** and **"b"**
      -  a) Import the file `Insomnia_dm113.json` to your favorite API Client.
      -  b) Execute the requests to test the service.

		
---

**Endpoints:**

If you decide to not import the configured collection that I have exported, below are the endpoints to be used to test the API.

```
gRPC localhost:5260 - (CadastroCliente/ListaClientes)    - Proto: cliente.proto
gRPC localhost:5260 - (CadastroCliente/CriarCliente)     - Proto: cliente.proto
gRPC localhost:5260 - (CadastroCliente/AtualizarCliente) - Proto: cliente.proto
gRPC localhost:5260 - (CadastroCliente/DeletarCliente)   - Proto: cliente.proto
gRPC localhost:5260 - (CadastroCliente/ObterCliente)     - Proto: cliente.proto
```

---

