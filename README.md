 # TestTask.WebApi
 Brief description - library API service with functions for managing books, authors and user accounts.
 
 ## Table of Contents
 * [Functionality](#functionality)
 * [Technology Stack](#technology-stack)
 * [Before Running](#before-running)
 * [How to use](#how-to-use)
 * [Notes](#notes)

## Functionality:

For unauthorized users:
- registration and authorization.

For authorized users:
- retrieve list of all books.
- retrieve list of all authors.
- retrieve list of all genres.
- retrieve a certain book by its Id or ISBN.
- adding a new book.
- change information about an existing book.
- book deletion.
- hiring/returning a list of books.
  
 ## Technology Stack:
 - .Net 7.0
 - Entity Framework Core
 - MS SQL
 - JWTBearer
 - Swagger

## Before Running

#### 1. Check out the repository

Clone this repository to your local machine.

#### 2. Find and open a file `appsettings.json`

Change the connection string
```bash
"ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
```
Apply the migrations to your database with the command
```sh
$  dotnet ef database update
```
Launch the application with the command
```sh
$  dotnet run --project .\TestTask.WebApi.csproj --launch-profile https
```
#### 3. Go to the application page
You can go to the application page at this link

https://localhost:7148/swagger/index.html

## How to use
1. First of all, you need to register.
2. After you have completed the previous step, you need to obtain your JWT-Token.
3. After that, you need to copy the JWT-Token and paste it into the "Authorize" window, but don't forget to put the word "Bearer" at the beginning.
4. Now your account is authorized you can use all features.
5. Let's add the necessary author.
6. Next, you need to get the Id of the author you added.
7. Second, add the necessary genre/s.
8. Now you can add your book by paste all required properties include genres, authors ids you added before.
9. After executing try to fetch all existing books where will be added book if the adding request was completed successfully.

## Notes
  1. A Clean Architecture/Onion Architecture architecture was chosen as the architecture for this assignment. This architecture includes 4 layers: presentation, application, infrastructure, core layers.
  2. Services chosed for instead of CQRS approach.
  3. Value id approach was chosen for guid shell due to more convenience.
  4. An unauthorized user will get a 401 error when trying to perform any operation exclude registration/login.
  5. Middlevares have been created for exception handling.
  6. Passwords are encrypted by algorithm before entering into the database.
  7. Added swagger annotations for more detailed descriptions of endpoints.
  8. Also described status codes that are returned after endpoints are executed.


  
