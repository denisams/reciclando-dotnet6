# reciclando-dotnet6

API REST simples em ASP.NET Core, criada como exercício de estudo (originalmente em .NET 6/7, modernizada para **.NET 10**). Expõe dois recursos:

- **Calculator** — operações matemáticas básicas (soma, subtração, multiplicação, divisão, média e raiz quadrada) recebidas via parâmetros de rota.
- **Person** — CRUD em memória (dados mockados, sem persistência real) para demonstrar injeção de dependência e o padrão Controller → Service.

## Stack

- .NET 10 (ASP.NET Core Web API)
- Swashbuckle/Swagger para documentação da API
- xUnit para testes automatizados

## Estrutura

```
RestwithAspnet/
├── RestiwithAspnet/            # API
│   ├── Controllers/            # CalculatorController, PersonController
│   ├── Model/                  # Person
│   ├── Services/                # IPersonService e implementação
│   └── Program.cs
├── RestiwithAspnet.Tests/       # Testes xUnit dos controllers e serviços
└── RestwithAspnet.sln
```

## Como executar

```bash
cd RestwithAspnet/RestiwithAspnet
dotnet run
```

A API sobe em `https://localhost:{porta}` (ver `Properties/launchSettings.json` ou a saída do `dotnet run`). Em ambiente de desenvolvimento, o Swagger UI fica disponível em `/swagger`.

## Como rodar os testes

```bash
cd RestwithAspnet
dotnet test
```

## Endpoints

### Calculator (`/api/calculator`)

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `sum/{firstNumber}/{secondNumber}` | Soma dois números |
| GET | `Subtraction/{firstNumber}/{secondNumber}` | Subtrai dois números |
| GET | `multiply/{firstNumber}/{secondNumber}` | Multiplica dois números |
| GET | `Division/{firstNumber}/{secondNumber}` | Divide dois números |
| GET | `Mean/{firstNumber}/{secondNumber}` | Calcula a média entre dois números |
| GET | `Square/{firstNumber}` | Calcula a raiz quadrada de um número |

Os números são recebidos como texto e validados; entradas inválidas retornam `400 Bad Request`.

### Person (`/api/person`)

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/` | Lista pessoas (mock) |
| GET | `/{id}` | Busca uma pessoa por id (mock) |
| POST | `/` | "Cria" uma pessoa (eco do payload enviado) |
| PUT | `/` | "Atualiza" uma pessoa (eco do payload enviado) |
| DELETE | `/{id}` | Remove uma pessoa (no-op) |

> `PersonService` é uma implementação mockada em memória — não há banco de dados. Serve como ponto de partida para plugar uma persistência real.
