## Project Information

To create the database, please follow these instructions:

1. Right-click on the solution and choose *Open in Terminal*.  
2. Execute the command: 
`dotnet ef database update -s Pri.Cocktails.Api -p Pri.Cocktails.Infrastructure` 

### Cocktail API

This API provides information about cocktails, including details on various aspects such as:

- **Tools**: Discover essential tools used in cocktail preparation.
  
- **Glasses**: Explore different types of glassware used for serving cocktails.

- **Ingredients**: Access a comprehensive list of ingredients used in crafting cocktails.

- **Recipes**: Uncover detailed recipes for creating a wide variety of cocktails.

- **And more**


### security
- Some security-sensitive information has been altered for my safety.
- Certificates in this project are self-generated for testing purposes.

### Docker
To Dockerize the project with MS-SQL DB, follow these steps:
1. Make sure to have a .env file with following variables(*I added .env to .gitignore to promote good practices.*):  
  - SA_PASSWORD=Pass1234  
  - ACCEPT_EULA=Y  
  - MSSQL_DATA_DIR=/var/opt/sqlserver/data  
  - MSSQL_LOG_DIR=/var/opt/sqlserver/log
  - MSSQL_BACKUP_DIR=/var/opt/sqlserver/backup
2. Use the comment out connection string in *appsettings.json*
3. Run the compose file.
5. Right-click on the solution and choose *Open in Terminal*. 
4. Run following command:  
`dotnet ef database update -s Pri.Cocktails.Api -p Pri.Cocktails.Infrastructure`  
