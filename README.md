# IncidentManagement

Tech Stack:

- ASP.NET Core Web API
- Entity Framework Core (Code First)
- AutoMapper
- FluentValidation
- MSSQL

In appsettings.Development.json, set your connection string:

Note:
If you get an error when running database updates (e.g. migrations),
replace the . in the connection string with your actual SQL Server instance name.

For example:
"Server=YOUR_SERVER_NAME;Database=IncidentManagement;Trusted_Connection=True;TrustServerCertificate=True"
