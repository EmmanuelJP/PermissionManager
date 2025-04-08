# PRM-BE
Permission Request Manager - API

# Introduction 
This is a project based on onion architecture that seeks to handle permission requests in a simple CRUD

# Getting Started
1.	Installation process
    - Clone or download the repository  
2.	Software dependencies
    - SQL Server
    - NET Core 3.1 SDK
    
# Build

1. Open the solucion file in Visual Studio (PRM.sln)
  - Set PRM.Api as StartUp Project
  - Restore Nuget Package
  - Rebuild solution 

#  Setup DB
  - Check your ConnectionString in the appSettings.json and make sure you can connect to SQL Server
  - Open Package Manager Console
  - Set PRM.Model as Default Project
  - Run these commands:
      ```bash
      add-migration {{migration-name}}
      update-database
      ```
 # Run
 - Visual Studio Press F5 or click debug button
 - Terminal  ```dotnet run```
