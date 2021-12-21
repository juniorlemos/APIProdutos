# APIProdutos
API de Produtos que contém um sistema de login utilizando Token JWT 

# Tecnologias Utilizadas.

### BackEnd
- C#
- DotNet core 5 
- Canducci Pagination
- Entity Framework
- MySQL
- Swagger 
- Automapper
- Fluent Validation
- XUnit
- Fluent Assertions
- Bogus
- NSubstitute
- Serilog
- Token JWT
- Docker
- Identity
- Cors

# Instalação
Para realizar a instalação da API faça os seguintes passos:
- Baixe e faça a instalação do sistema Mysql através do site https://www.mysql.com/
- Baixe e faça a instalação do .Net Runtime através do site https://dotnet.microsoft.com/en-us/download 
- Clone o projeto ou faça download dele zipado 
- Após isso descompacte o projeto e abra o terminal de comando
- Altere a string de conexão com o banco de dados , ajuste de acordo com a configuração dos seu banco , a string está localizada na classe ConfigureRepository
- No terminal de comando acesse  a pasta do projeto e digite o comando "dotnet run" para executar a API 
- no terminal copie e cole o endereço gerado pela Api no navegador

# Funcionalidades da API.

A API desenvolvida contém os  controllers:  Account e Produtos , além das seguintes funcionalidades  mostradas na  figura abaixo gerada pelo Swagger , inclue também autenticação utilzando Token JWT 

![Capturar](https://user-images.githubusercontent.com/47072463/144960997-58bfdd15-d3c2-42fe-b4b4-2ea980f8e026.PNG)

### Testes

Para testar a API foram realizados Testes Unitários  e alguns cenários foram testados utilizando a ferramenta Postman
