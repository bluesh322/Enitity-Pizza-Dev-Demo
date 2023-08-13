# Enitity-Pizza-Dev-Demo
Entity Framework Pizza Demo Dev Environment

# BookStoresDB tutorial

# Setup
## Tools and Env
* VS 2019 (C#)
* Microsoft SQL Server
* Microsoft SQL Server Management Studio
* Docker

## Repo Copy Setup

## Use EF Database-First command line
1. In SQL create Database "BookStoresDB".
2. Use query located at database\bookStoresDB.sql and Run.
3. Should see tables and relations set up.
4. Open Package Manager Console
5. Run: "Scaffold-DbContext -Connection Name=BookStoresDB Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force"
> -force flag is there for repeat runs of Scaffold when schema changes.
