# Projeto drugovich.autopecas

## Descrição

O projeto "drugovich.autopecas" é uma Web API desenvolvida para a gestão de clientes, grupos e gerentes, simulando um cenário de um backend para um sistema de loja de autopeças.

## Tecnologias Utilizadas

- ASP.NET Core 6: Utilizado como framework web para desenvolvimento da API.
- Banco de Dados em Memória com Entity Framework Core: O banco de dados em memória foi escolhido para armazenamento de dados.
- Swagger: A interface do Swagger é utilizada para expor os endpoints da API, onde é possível acessar os recursos e se autenticar diretamente pela sua interface.

## Arquitetura

A arquitetura da aplicação segue o conceito de Onion Architecture, onde as dependências fluem de dentro para fora, respeitando o princípio de inversão de controle (IoC). O projeto está dividido nas seguintes camadas:

- **drugovich.autopecas.api**: Web API que expõe os endpoints para interação com a aplicação.
- **drugovich.autopecas.application**: Camada de aplicação que contém as regras de negócio, interfaces e serviços da aplicação.
- **drugovich.autopecas.infrastructure**: Camada com a implementação dos repositórios e acesso ao banco de dados.
- **drugovich.autopecas.core**: Camada que contém as entidades, enums e exceções da aplicação.

## Passos para Executar

Você pode executar a aplicação de duas maneiras:

### Execução pelo Visual Studio 2022/Rider

1. Abra o projeto no Visual Studio 2022 ou Rider.
2. Certifique-se de que as dependências do projeto estejam corretamente configuradas.
3. Inicie a aplicação a partir do ambiente de desenvolvimento.

### Execução como Container Docker

1. Certifique-se de que o Docker esteja instalado em sua máquina.
2. Abra um terminal e navegue até o diretório raiz do projeto.
3. Execute o seguinte comando para construir a imagem e executar o container:

   ```bash
   docker-compose up -d
   ```

4. Após a construção da imagem e a execução do container, você poderá acessar a aplicação por meio da seguinte URI:

   [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html)

5. Para acessar os endpoints protegidos, siga os seguintes passos:

    - Utilize o endpoint de "Gerentes" para criar um novo gerente.
    - Faça login com o gerente criado para obter um token de autenticação.
    - Utilize o token obtido para autenticar-se na interface do Swagger.

A aplicação já inicia com alguns dados carregados para testes, e você pode se autenticar com o email `gerente2@email.com`.

Agora você está pronto para começar a explorar e utilizar a API de gerenciamento de autopeças.

---

**Nota**: Certifique-se de que todas as dependências e pré-requisitos estejam instalados e configurados corretamente antes de executar a aplicação. Para mais informações, consulte a documentação do ASP.NET Core e do Docker.