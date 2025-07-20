# Entity Framework Core - Migrations Setup

This project uses [Entity Framework Core](https://learn.microsoft.com/en/ef/core/) for database access and schema migrations. All EF Core migrations are placed in the `Data/Migrations` folder for better organization and maintainability.

## 🛠 Creating a Migration

To add a new migration, run the following command from the project root:

```bash
dotnet ef migrations add <MigrationName> -o Data/Migrations
