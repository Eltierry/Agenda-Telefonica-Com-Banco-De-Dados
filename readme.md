# Agenda Telefônica com Banco de Dados



## Sobre o projeto
![NPM](https://img.shields.io/badge/STATUS_-Em_Desenvolvimento-greee)
xxxxx


## Documentação e fonte de pesquisa
* Microsoft: [xxxx](xxx) 
* Microsoft: [xxxxx](xxx) 
* Microsoft: [xxxx](xxx) 

## Tecnologias utilizadas
### Back end
- C#
### Banco de dados
- MySql
## Pré-requisitos
[.Net 6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0).

## Criar projeto

```Csharp
dotnet new console -n <NomeDoProjeto> -f net6.0
```
## Ferramentas necessárias

```Csharp
// Entity Framework
dotnet tool install --global dotnet-ef

// Framework para trabalhar com MySql
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0

// Pacote Design do Entity Framework
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0

// Pacote Design do Entity Framework Pomelo
dotnet add package Pomelo.EntityFrameworkCore.MySql.Design --version 1.1.2
```
## Pasta Context e conexão com o Banco de Dados

Crie uma pasta "Context" para adicionar

Observação: xxxxx

```csharp
//optionsBuilder.UseMySql("server=localhost;port=3306;userid=root;password=;database=MinhaAgenda", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"))
string conectionString = "server=localhost;port=3306;userid=root;password=123456789;database=MinhaAgenda";
var serverConncetion = ServerVersion.AutoDetect(conectionString);
optionsBuilder.UseMySql(conectionString, serverConncetion);
```
## Primeira Migration
```
// Executa primeeira para onde o Entity Framework criará uma pasta chamada "Migration" contendo 
//todas as alterações na estrtura do banco de dados
dotnet ef migrations add "Primeira Migration"
```
## Update 
```
// Se não existe um banco de daddos, será criado um.
// Se existe um, será atualizado a estrtura de tabelas.
dotnet ef database update
```

## Como executar a aplicação
Digitar o comando no terminal:
```
dotnet run
```


## Telas
### Resultado
 xxxxx
 ```

```



## Agradecimentos
[Professor Nélio Alves](https://www.linkedin.com/in/nelio-alves/) 

## Contribuição
Os pull requests são bem-vindos. Para mudanças importantes, abra um problema primeiro para discutir o que você gostaria de mudar.
Certifique-se de atualizar os testes conforme apropriado.

## License
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/Eltierry/Agenda-Telefonica-Com-Banco-De-Dados/blob/main/LICENSE)


