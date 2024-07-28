
# Book Management API using Fast Endpoints , Entity Framework 8, and .NET 8.

ASP.NET Minimal APIs Made Easy.
FastEndpoints is a developer friendly alternative to Minimal APIs & MVC

## Acknowledgements

 - [FashEndpoints](https://fast-endpoints.com/)
 - [How to use](https://www.infoworld.com/article/2515537/how-to-use-fastendpoints-in-asp-net-core.html#:~:text=Register%20the%20FastEndpoints%20library,Services.)
 - [Enity Framework core](https://docs.microsoft.com/en-us/ef/core/)
 

## Getting Started

### Prerequisites
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/vs/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server (LocalDB)](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
### Setting Up the Project
Step 1: Create a New .NET 8 Project.

 - Open Visual Studio.

- Select Create a new project.
- Choose ASP.NET Core Web API and click Next.
- Name your project BookManagementAPI, choose a location, and click Create.
- On the next screen, ensure .NET 8 is selected in the Framework dropdown and click Create.

Step 2: Add Fast Endpoints NuGet Package

- Right-click on the project in the Solution Explorer and select Manage NuGet Packages.
- Go to the Browse tab, search for FastEndpoints, select it, and click Install.

Step 3: Update Program.cs

Step 4: Create an Endpoint
- Create a new endpoint by adding a class to your project.
-  For example, create a new folder named Endpoints and add a file named GetBooksEndpoint.cs with the following content:

- Right-click on the project in the Solution Explorer and select Add > New Folder. Name it Endpoints.
- Right-click on the Endpoints folder, select Add > Class. Name it - GetBooksEndpoint.cs and click Add.
- Replace the content of GetBooksEndpoint.cs with the following code:

Step 5:Create and Update the Database

- Open the Package Manager Console in Visual Studio:

- Go to View > Other Windows > Package Manager Console.

- Add-Migration InitialCreate

 - Update-Database
### Configuration

Ensure that your appsettings.json is correctly configured with the connection string to your LocalDB instance.
### Running the Application
Using Visual Studio

In Solution Explorer, right-click on the BooksManagementAPI project and select Set as Startup Project.
Press F5 or click on the Start button to build and run the application.




## API Reference

#### Get all items

```http
  GET /api/Books
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_Books` | `string` | **Required**.  |


#### Get book

```http
  GET /api/books/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Books`      | `string` | **Required**. Id of book to fetch |


- Add a Book

Endpoint: POST /books

```http
Request Format:{
  "title": "string",
  "author": "string",
  "isbn": "string"
}
```

```http

Response Format:{
  "id": "int",
  "title": "string",
  "author": "string",
  "isbn": "string"
}
```

- Get a Book by ID

Endpoint: GET /books/{id}

```http
 
Response Format:{
  "id": "int",
  "title": "string",
  "author": "string",
  "isbn": "string"
}
```

- Get All Books

Endpoint: GET /books

```http
Response Format:[
  {
    "id": "int",
    "title": "string",
    "author": "string",
    "isbn": "string"
  },
  
]
```

- Update a Book

Endpoint: PUT /books/{id}

```http

Request Format:{
  "title": "string",
  "author": "string",
  "isbn": "string"
}
```

```http

Response Format:{
  "id": "int",
  "title": "string",
  "author": "string",
  "isbn": "string"
}
```





## Assumptions and Design Decisions
- Database Choice: SQL Server (LocalDB) was chosen for simplicity and ease of setup. It can be replaced with a full SQL Server or another database provider as needed.

- Frameworks: Fast Endpoints and Entity Framework 8 were chosen for their performance and ease of use.

- Architecture: A simple, monolithic architecture was used to keep the project straightforward and easy to understand.

- Error Handling: Basic error handling is implemented in the endpoints. More robust error handling and logging can be added as needed.

- Authentication and Authorization: Not implemented in this simple example but can be added based on requirements.

- Testing: Unit and integration tests are not included in this example but should be added for production applications.