# EntityFramework Core Classes

As I am using [GitHub Codespaces](https://github.com/features/codespaces) along with Visual Studio Code to generate code, some of the Migration commands are different.
In this case there is a tool called [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) that works similar to Migrations running in Visual Studio Package Manager.

## Adding dotnet-ef reference

``` csharp

dotnet tool install --global dotnet-ef

```

## Adding reference

``` csharp

dotnet add package Microsoft.EntityFrameworkCore.Design

```

## Creating Initial Migration

``` csharp

dotnet ef migrations add InitialCreate

```

## Updating Database with Migrations

``` csharp

dotnet ef database update

```
