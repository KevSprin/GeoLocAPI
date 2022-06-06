# GeoLocAPI

This API provides a basic set of functionalities for creation of geolocalization data based on the URL or IP address. 
To get this project started simply clone the repository, set the docker-compose project as Starup (if it's not already selected) and then run the project.
Upon first build the migration will be automatically run before the webpage will load. It will provide sample users data and sample geolocation data.
When the page will finish loading, you can use `admin` as username and `admin` as password for authentication. You'll have to copy the JWA token from the response body and paste it in the `Authorize` modal in Swagger (invoked by the green `Authorize` Button).
If everything went well you should be able now to access all provided endpoints.

Technologies used:
- C# 6.0 with ASP.NET Core API
- EntityFramework Core 6.0.5
- Swagger (Swashbuckle) 6.2.3
- BCrypt.Net-Core 1.6.0
- Moq 4.18.1
- NUnit 3.13.2
- Automapper 11.0.0
- Microsoft SQL Server 2019 (Docker Image)
- Docker with Linux Container with Docker Compose
