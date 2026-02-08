# MoviesAPI

RESTful API for managing movie data, built with **ASP.NET Core (.NET 7)**.  
The API provides endpoints to create, retrieve, update, and delete movies, using **SQLite** for data persistence and **Swagger** for API documentation. **Basic Authentication** is implemented to protect write operations (POST, PUT, PATCH, DELETE).

---

## Technology Stack

- ASP.NET Core Web API (.NET 7)  
- Entity Framework Core  
- SQLite  
- AutoMapper  
- Swagger (Swashbuckle)  
- Newtonsoft.Json  
- Basic Authentication  

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

## Authentication

Endpoints that **modify data** (POST, PUT, PATCH, DELETE) require **Basic Authentication**.

- Username: `admin`  
- Password: `123456`  

Add the following header to your request:

`Authorization: Basic YWRtaW46MTIzNDU2`

(`YWRtaW46MTIzNDU2` is the Base64 encoding of `admin:123456`)

### Example with curl (POST a new movie)

```bash
curl -X POST https://localhost:7106/Movie \
-H "Authorization: Basic YWRtaW46MTIzNDU2" \
-H "Content-Type: application/json" \
-d '{"title":"Matrix","genre":"Sci-Fi","duration":120}'


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
