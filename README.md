# Task Manager (FrontEnd)
- **Next js**: estrutura de desenvolvimento web para React.

## Executar local
1. conectar o back end
2. instalar as dependencias do projeto
 ```
 npm install ou yarn install
```
3.  Rodar aplicação
 ```
 npm run dev ou yarn run dev
```

## visual da aplicação

![image](https://github.com/larissa1998/ToDoListTest/assets/19778881/38f492df-9640-4823-b80e-4a22ed0be02b)


# Task Manager API (BackEnd)

Este projeto é uma API RESTFul para gerenciamento de tarefas, permitindo operações CRUD (Criar, Ler, Atualizar, Deletar) sobre tarefas. Foi desenvolvido usando C# e .NET 7, empregando o Entity Framework Core para interação com o banco de dados SQL Server.

## Tecnologias Usadas

- **.NET 7**: Plataforma de desenvolvimento para construir aplicações web.
- **Entity Framework Core**: ORM (Object-Relational Mapper) utilizado para abstração de acesso ao banco de dados.
- **SQL Server**: Sistema de gerenciamento de banco de dados relacional.

## Pré-requisitos

Para executar este projeto, você precisará das seguintes ferramentas instaladas em seu sistema:
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Você pode usar qualquer versão que prefira, incluindo LocalDB para desenvolvimento local)
- [Visual Studio](https://visualstudio.microsoft.com/vs/) (Opcional, se preferir outro editor de texto)

## Configuração

### Banco de Dados

1. Certifique-se de que o SQL Server está instalado e rodando.
2. Crie uma base de dados chamada `TaskManagerDB` ou ajuste a string de conexão conforme necessário no arquivo `appsettings.json`.

### String de Conexão

Localize o arquivo `appsettings.json` e substitua a string de conexão com a apropriada para o seu ambiente de SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagerDB;Trusted_Connection=True;"
}
```

## Executando o Projeto

### Via linha de Comando
1. Abra o terminal ou prompt de comando
2. Navegue até o diretório onde o projeto está localizado
3. Execute o comando para restaurar os pacotes necessários
```
dotnet restore
```
4. Execute o comando para construir o projeto
```
dotnet build
```
5. Antes de executar a aplicação, aplique as migrations para configurar o banco de dados
```
dotnet ef database update
```
6. Execute o projeto
```
dotnet run
```

## Via Visual Studio
1. Abra o projeto
2. Pressione 'Ctrl+F5' para construir e executar o projeto sem anexar o debugger

### Usando a API
Após iniciar o projeto, a API estará disponível por padrão em http://localhost:5000. Você pode acessar os endpoints usando qualquer cliente HTTP, como Postman ou cURL

#### Endpoints da API
- GET /api/tasks: Lista todas as tarefas.
- GET /api/tasks/{id}: Retorna uma tarefa específica pelo ID.
- POST /api/tasks: Cria uma nova tarefa.
- PUT /api/tasks/{id}: Atualiza uma tarefa existente.
- DELETE /api/tasks/{id}: Deleta uma tarefa pelo ID.

## Contribuindo
Se deseja contribuir para o projeto, sinta-se à vontade para abrir um pull request ou uma issue. Toda contribuição é bem-vinda!
