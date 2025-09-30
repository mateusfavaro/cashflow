## Sobre o projeto

A API foi desenvolvida em **.NET 8** seguindo os princípios do **Domain-Driven Design (DDD)**, oferecendo uma solução organizada e eficiente para o gerenciamento de despesas pessoais. Seu propósito é permitir que os usuários registrem seus gastos de forma detalhada, incluindo informações como título, data e hora, descrição, valor e tipo de pagamento, sendo todos os dados armazenados com segurança em um banco de dados **MySQL**. 

A arquitetura é baseada no padrão **REST**, utilizando métodos **HTTP** convencionais para garantir uma comunicação simples e eficaz, e conta ainda com documentação via **Swagger**, que disponibiliza uma interface gráfica interativa para que os desenvolvedores possam explorar e testar os endpoints de maneira prática. Para otimizar a implementação, são utilizados pacotes NuGet como o **AutoMapper**, responsável pelo mapeamento entre objetos de domínio e modelos de requisição e resposta, reduzindo a repetição de código; o **FluentAssertions**, empregado em testes de unidade para tornar as verificações mais legíveis e compreensíveis; e o **FluentValidation**, que facilita a definição de regras de validação diretamente nas classes de requisição, contribuindo para um código limpo e de fácil manutenção. 

Por fim, a interação com o banco de dados é simplificada pelo **Entity Framework**, que atua como ORM (Object-Relational Mapper), permitindo manipular dados por meio de objetos **.NET** sem a necessidade de escrever consultas SQL manualmente.

### Features

- **Domain-Driven Design (DDD):** Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade:** Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **Geração de Relatórios:** Capacidade de exportar relatórios detalhados para Excel, oferecendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentação Swagger:** Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

### Construido com
![badge-dot-net]
![badge-windows]
![badge-mysql]
![badge-swagger]

## Getting Started

Para obter uma copia local do projeto, siga o passo a passo.

### Requisitos

- Visual Studio versão 2022+
- Windows 10+ ou Linux/MacOS com [.NET SDK][dot-net-sdk] instalado
- MySql Server

### Instação

1. Clone o repositório: 
```sh
git clone https://github.com/mateusfavaro/cashflow.git
```

2. Preencha as informações no arquivo `appsettings.Development.json`.
3. Execute a API.


<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.414-windows-x64-installer

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=plastic
[badge-windows]: https://img.shields.io/badge/Git%20for%20Windows-80B3FF?logo=gitforwindows&logoColor=fff&style=plastic
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=plastic
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=plastic