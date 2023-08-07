# Desafio Técnico - Backend

O propósito desse desafio é a criação de uma API que fará a persistência de dados de um quadro de kanban. Esse quadro possui listas, que contém cards.

## Clonando o Projeto

```console
> git clone https://github.com/ysouzas/desafio-tecnico-backend.git
```

## Rodando o Frontend e Database

Crie um arquivo .env, com os seguintes dados

````plaintext
SQL_SERVER_PORT=...
SA_PASSWORD=...
FRONTEND_PORT=...

Na raiz do projeto rode o comando

```console
> docker-compose up
````

## Rodando o Backend

Abra o projeto no visual studio

crie um arquivo chamado appsettings.json com essa estrutura:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "..."
  },
  "AllowedHosts": "...",
  "JwtSettings": {
    "Secret": "...",
    "ExpirationHours": ...,
    "Audience": "...",
    "Issuer": "..."
  },
  "AdminSettings": {
    "Login": "...",
    "Senha": "..."
  }
}
```

## Logging

O `Logging` é responsável por definir o nível de log para diferentes categorias na aplicação.

- `LogLevel`: Define o nível de log para diferentes categorias.
  - `Default`: Nível padrão para logs em geral. Exemplo: `"Default": "Information"`.
  - `Microsoft.AspNetCore`: Nível de log para logs relacionados ao Microsoft.AspNetCore. Exemplo: `"Microsoft.AspNetCore": "Warning"`.

## ConnectionStrings

Aqui estão as configurações relacionadas à conexão com o banco de dados. A chave `DefaultConnection` contém a string de conexão com o banco de dados SQL Server. Esta string define os parâmetros necessários para estabelecer a conexão, como o servidor, o nome do banco de dados, o usuário e a senha.

## AllowedHosts

A propriedade `AllowedHosts` indica os hosts que podem acessar a aplicação. Neste caso, o valor "\*" permite que qualquer host acesse a aplicação. Em ambientes de produção, é recomendado definir explicitamente os hosts permitidos para melhor segurança.

## JwtSettings

Essa seção contém as configurações relacionadas à autenticação JSON Web Token (JWT). O JWT é um mecanismo usado para autenticação e autorização. Aqui estão as propriedades:

- `Secret`: Chave secreta usada para assinar e verificar o token JWT.
- `ExpirationHours`: Tempo de expiração do token em horas.
- `Audience`: Audiência ou público-alvo do token, que indica para quem o token é destinado. Neste caso, é definido como "http://localhost:3000/".
- `Issuer`: Emissor do token, que indica qual serviço emitiu o token. Neste caso, é definido como "http://localhost:5000/".

## AdminSettings

Esta seção contém as configurações do administrador da aplicação. Aqui estão as propriedades:

- `Login`: Nome do usuário .
- `Senha`: Senha do usuário.

Lembre-se de que este arquivo contém informações sensíveis, como senhas e chaves secretas. Mantenha-o protegido e não o compartilhe publicamente, principalmente em repositórios de código aberto.

Para maiores informações sobre as configurações específicas da aplicação, consulte a documentação ou os responsáveis pelo desenvolvimento do projeto.
