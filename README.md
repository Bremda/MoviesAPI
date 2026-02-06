# MoviesAPI

RESTful API for managing movie data, built with **ASP.NET Core (.NET 7)**.  
The API provides endpoints to create, retrieve, update, and delete movies, using **SQLite** for data persistence and **Swagger** for API documentation.

---

## Technology Stack

- ASP.NET Core Web API (.NET 7)
- Entity Framework Core
- SQLite
- AutoMapper
- Swagger (Swashbuckle)
- Newtonsoft.Json

---

## Getting Started

### Prerequisites

- .NET SDK 7.0 or later

### Running the Application

    dotnet restore
    dotnet run

The API will be available at:

    https://localhost:7106
    http://localhost:5106

---

## API Documentation

Swagger UI is available at:

    https://localhost:7106/swagger

The Swagger interface provides a full overview of available endpoints and allows interactive request testing.

---

## Endpoints Overview

> Endpoint routes may vary depending on implementation.

### Get all movies

    GET /api/movies

### Get movie by ID

    GET /api/movies/{id}

### Create a new movie

    POST /api/movies

Example request body:

    {
      "title": "The Godfather",
      "director": "Francis Ford Coppola",
      "year": 1972,
      "genre": "Drama"
    }

### Update a movie

    PUT /api/movies/{id}

### Delete a movie

    DELETE /api/movies/{id}

---

## Database

- Database: **SQLite**
- ORM: **Entity Framework Core**

To apply database migrations:

    dotnet ef migrations add InitialCreate
    dotnet ef database update

---

## Configuration

- Environment: `Development`
- Nullable reference types enabled
- Implicit global usings enabled

---

## License

This project is intended for learning and development purposes.
