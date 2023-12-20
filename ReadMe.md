## Project Information

### Cocktail API

This API provides information about cocktails, including details on various aspects such as:

- **Tools**: Discover essential tools used in cocktail preparation.
  
- **Glasses**: Explore different types of glassware used for serving cocktails.

- **Ingredients**: Access a comprehensive list of ingredients used in crafting cocktails.

- **Recipes**: Uncover detailed recipes for creating a wide variety of cocktails.

- **And more**



### securety
- Some security-sensitive information has been altered for my safety.
- Certificates in this project are self-generated for testing purposes.

### Docker
I have been experimenting with Docker in this project.  
Run the compose file ,use the comment out connection string, then run following command:  
`dotnet ef database update -s Pri.Cocktails.Api -p Pri.Cocktails.Infrastructure`  
Make sure to have a .env file with following variables:  
- SA_PASSWORD=Pass1234  
- ACCEPT_EULA=Y  
- MSSQL_DATA_DIR=/var/opt/sqlserver/data  
- MSSQL_LOG_DIR=/var/opt/sqlserver/log
- MSSQL_BACKUP_DIR=/var/opt/sqlserver/backup