# MaximaTech - Sistema de Gerenciamento de Produtos

## Descrição
Este é o sistema de gerenciamento de produtos da MaximaTech, uma aplicação ASP.NET MVC que permite aos usuários visualizarem, criarem, editarem e deletarem produtos.
Ele se integra com uma API para realizar operações de CRUD nos produtos.

## Funcionalidades
- Listagem de produtos, departamentos;
- Visualização detalhada de um produto;
- Criação de novos produtos;
- Edição de produtos existentes;
- Deleção de produtos;

## Tecnologias Utilizadas
- ASP.NET Core MVC, RestSharp
- ASP.NET Core WebAPI, C#, MediaR, Moq, FluentValidation, Identity
- Entity Framework Core
- REST API
- HTML/CSS
- Bootstrap
- PostgreSQL
- Swagger


## Pré-requisitos
- .NET Core SDK
- Visual Studio ou Visual Studio Code
- PostgreSQL e PGAdmin.

## Como Executar
1. Clone o repositório: `git clone https://github.com/Rwwo/rwwo.MaximaTech-.git`
2. Abra o projeto em seu IDE preferido (Visual Studio, Visual Studio Code, etc.)
3. Para o banco de dados e o PGAdmin, foi utilizado containers Docker. 
   O arquivo pgadmin_postgres.yml na raiz do projeto api contém a configuração necessária para executar o PostgreSQL e o PGAdmin em containers. 
   Os scripts de inserção de departamentos estão em um arquivo SQL.txt dentro do projeto da api.
   *Obviamente* é possível utilizar qualquer instância de banco de dados postgres já existente no host. Bastando ajustar a string de conexão.
4. Configure a conexão com a banco de dados no arquivo `appsettings.json` (já deve estar correta, mas caso tenha alterado algo)
5. Execute a aplicação


