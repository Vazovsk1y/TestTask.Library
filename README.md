# TestTask.Library

Web API for library simulation.

## Functionality:

### For Unauthorized Users:
- Registration and authorization.

### For Authorized Users:
- Retrieve a list of all books.
- Retrieve a list of all authors.
- Retrieve a list of all genres.
- Retrieve a specific book by its Id or ISBN.
- Add a new book.
- Update information about an existing book.
- Delete a book.
- Hire or return a list of books.

## Technology Stack:
- .NET 7.0
- Entity Framework Core
- MS SQL
- JWT Bearer Auth
- Swagger

## Before Running

### 1. Clone the Repository

Clone this repository to your local machine.

### 2. Update the Configuration File

Find and open the `appsettings.json` file and update the connection string:
```json
"ConnectionStrings": {
"Default": "YOUR_CONNECTION_STRING"
},
```

### 3. Launch the Application

Run the following command to launch the application:
```sh
$ dotnet run --project .\TestTask.WebApi.csproj --launch-profile https
```

## Notes
1. A Clean/Onion architecture was chosen for this project. This architecture includes four layers: presentation, application, infrastructure, and core.
2. Services were chosen instead of the CQRS approach.
3. The Value ID approach was chosen for GUIDs due to its convenience.
4. Unauthorized users will receive a 401 error when trying to perform any operation other than registration or login.
5. Middleware has been created for global exception handling.
6. Passwords are encrypted using an algorithm before being stored in the database.
7. Swagger annotations have been added for more detailed descriptions of endpoints.
8. Status codes that are returned after endpoints are executed are also described.