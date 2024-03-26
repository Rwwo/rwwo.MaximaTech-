# MaximaTech - Sistema de Gerenciamento de Produtos

## Descri��o
Este � o sistema de gerenciamento de produtos da MaximaTech, uma aplica��o ASP.NET MVC que permite aos usu�rios visualizarem, criarem, editarem e deletarem produtos.
Ele se integra com uma API para realizar opera��es de CRUD nos produtos.

## Funcionalidades
- Listagem de produtos, departamentos;
- Visualiza��o detalhada de um produto;
- Cria��o de novos produtos;
- Edi��o de produtos existentes;
- Dele��o de produtos;

## Tecnologias Utilizadas
- ASP.NET Core MVC, RestSharp
- ASP.NET Core WebAPI, C#, MediaR, Moq, FluentValidation, Identity
- Entity Framework Core
- REST API
- HTML/CSS
- Bootstrap
- PostgreSQL
- Swagger


## Pr�-requisitos
- .NET Core SDK
- Visual Studio ou Visual Studio Code
- PostgreSQL e PGAdmin.

## Como Executar
1. Clone o reposit�rio: `git clone https://github.com/Rwwo/rwwo.MaximaTech-.git`
2. Abra o projeto em seu IDE preferido (Visual Studio, Visual Studio Code, etc.)
3. Para o banco de dados e o PGAdmin, foi utilizado containers Docker. 
   O arquivo pgadmin_postgres.yml na raiz do projeto api cont�m a configura��o necess�ria para executar o PostgreSQL e o PGAdmin em containers. 
   Os scripts de inser��o de departamentos est�o em um arquivo SQL.txt dentro do projeto da api.
   *Obviamente* � poss�vel utilizar qualquer inst�ncia de banco de dados postgres j� existente no host. Bastando ajustar a string de conex�o.
4. Configure a conex�o com a banco de dados no arquivo `appsettings.json` (j� deve estar correta, mas caso tenha alterado algo)
5. Execute a aplica��o


