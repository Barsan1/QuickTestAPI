# :rocket: QuickTestAPI

Fast dotnet API project with entity framework core.  
Aim for fast testing queries with mssql DB

## How to start : 

:white_check_mark: Clone the project to your machine
```powershell
git clone https://github.com/Barsan1/QuickTestAPI.git
```

:white_check_mark: Add your connection string in appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Mssql-TestDB": "<Enter connection string here>" // Connection string here
  }
}
```

:white_check_mark: Update database migration script with CLI
```
# Navigate to API project 
cd  .\API\

# Run migration
dotnet ef database update -v
```

### Run project (Press F5) 
This will open swagger with 2 endpoints :
1. Get all pepole from db
2. Add generated pepole to db
