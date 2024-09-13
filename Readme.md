# Movie Library App Rework Using EF

## Overview

The Movie Library App is a Windows Forms application built to manage a personal movie library. This project serves as a learning exercise in C# development using a Minimal API with Entity Framework Core. The app features CRUD operations, where users can create, read, update, and delete movies. The WinForms app interacts with the API through HTTP requests, fetching data asynchronously using DTOs (Data Transfer Objects).

This project is for learning key concepts in async/await, Object Relational Mapping (ORM), and Minimal APIs in .NET. 
## Features

- **Create**: Add new movies to the library, including details such as title, release year, description, and whether you’ve seen them.
- **Read**: Fetch the list of movies or specific movie details from the API.
- **Update**: Edit movie information via the API and reflect changes in the WinForms UI.
- **Delete**: Remove movies from the collection.
- **Async requests**: All API calls in the  made asynchronously to provide a responsive user experience.

## Technologies Used

- **Minimal Api**: For backend logic that handles CRUD operations and data processing.
- **Entity Framework**: Used for data access and manipulation with the database.
- **WinForms**: Windows Forms is used to build the user interface that consumes the API.

### Api Endpoints
GET /movies: Fetch all movies.
GET /movies/{id}: Fetch a single movie by its ID.
POST /movies: Add a new movie.
PUT /movies/{id}: Update a movie’s details.
DELETE /movies/{id}: Remove a movie.

### Project Architecture : N-Tier Architecture 
Web Application :

    -Minimal API: Handles requests and interacts with the database.
      
         -DTOs: Data Transfer Objects help manage the flow of data between the API and WinForms.
         
         -Mapping: maps the Movie model to GetDTO or from Movie model to CreateDTO.
         
         -Middleware: RequestTimingMiddleware to measure the response time it takes for each request.
         
    
    -WinForms App: Acts as the client, making HTTP requests to the API.
    
    -MovieLibBusiness: Contains services logic , datacontext and ef migrations.
    
    -MovieLibBusiness Tests: Used for implementing unit testing.

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET Core 8.0 or later
- SQL Server (for database management)

### Setup Instructions

1- Clone the Repository:
    git clone https://github.com/Marcogeorgez/MovieLibrary.git
    
2- Configure Database: Update the connection string in user secrets with your SQL Server details.

3-Run Migrations: Navigate to the MovieLib.Business project directory and run the following command to apply the EF Core migrations and create the database:

4-Run the API: Start the Minimal API project to host the backend service.

