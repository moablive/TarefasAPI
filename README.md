# TarefasAPI

Este é um exemplo de um aplicativo de tarefas simples que usa o Dapper para interagir com um banco de dados SQL Server.

## Pré-requisitos

Antes de executar o aplicativo, certifique-se de ter instalado o .NET Core SDK e as seguintes dependências:

- SQL Server (ou SQL Server Express)
- Um banco de dados vazio para o aplicativo

## Pré-requisitos

Antes de executar o aplicativo, certifique-se de ter instalado o .NET Core SDK e as seguintes dependências:

- Docker (para executar o SQL Server em um contêiner)

## Configuração do Banco de Dados

Você pode configurar um banco de dados SQL Server para o aplicativo executando um contêiner Docker com o SQL Server. Você pode usar o seguinte comando para criar e executar um contêiner SQL Server:

```shell
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Your@Strong#Password1234' -p 1433:1433 --name sqlservercontainer -d mcr.microsoft.com/mssql/server:2019-latest
```

## Configuração do Banco de Dados

Você pode criar um banco de dados para o aplicativo executando os seguintes comandos SQL:

```sql
CREATE DATABASE TarefasDemoDB;
USE TarefasDemoDB;
GO
CREATE TABLE [dbo].Tarefas (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Atividade] [nvarchar](255),
    [Status] [nvarchar](255)
);
GO
```
