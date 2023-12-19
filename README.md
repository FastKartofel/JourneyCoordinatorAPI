### JourneyCoordinatorAPI
### Overview
- JourneyCoordinatorAPI is a RESTful web service developed with ASP.NET Core and Entity Framework Core. It is designed to manage trips, clients, and their associations in a travel management context. Leveraging the power of Entity Framework Core, the API facilitates seamless interactions with Microsoft SQL Server, enabling operations like assigning clients to trips, retrieving detailed trip information, and listing all trips along with associated clients and countries.

### Features
- List all trips, including details about associated countries and clients.
- Retrieve detailed information about specific trips.
- Assign clients to trips, with the capability to create new clients as needed.

### Getting Started
### Prerequisites
- .NET Core SDK
- Microsoft SQL Server
- Entity Framework Core

### Required NuGet Packages
- **Make sure to install the following NuGet packages**:

- Microsoft.EntityFrameworkCore: The core library for Entity Framework.
- Microsoft.EntityFrameworkCore.SqlServer: The SQL Server database provider for Entity Framework Core.
- Microsoft.EntityFrameworkCore.Tools: Provides necessary tools for using Entity Framework Core.
