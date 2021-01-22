# PortalAPI

API desenvolvida em .NET v2.2 para ser a base de uma plataforma de doações, onde é possível se cadastrar e criar doações ou também solicitar doações já existentes no banco de dados.


### Tecnologias utilizadas: 

- C# .NET Core 2.2
- Entity Framework Core
- AutoMapper
- JWT
- MySql

### Configurações necessárias:

Arquivo appsettings.json na pasta raiz do projeto.

```
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;userid=root;password=123456;database=PortalAPI" //Configurações do banco de dados
  },
  "JwtSettings": {
    "SecretKey": "SECRET_KEY_GENERATE_TOKEN", //Hash para gerar o JWT
  },
  "Email": {
    "UserName": "EMAIL", //Email para envio de recuperação senha
    "Password": "PASSWORD" //Senha do Email 
  },
  "PasswordKey":  "PASSWORD_HASH_ENCRYPT" //Hash para criptografia de senha
```
### Criar Banco de Dados

O projeto usa o conceito CODE FIRST, onde o banco de dados é criado após a codificação das classes do projeto.

Para criar o banco de dados MySQL, rode os comandos no console do projeto

```
add-migration NOME_PARA_MIGRAÇÃO
update-database
```


