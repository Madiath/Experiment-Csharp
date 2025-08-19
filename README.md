To make this solution work, you will need the following NuGet packages:

Microsoft.AspNetCore.Authentication.JwtBearer: For handling JSON Web Token (JWT) authentication.
Microsoft.EntityFrameworkCore: For using Entity Framework Core to manage database access.
Microsoft.EntityFrameworkCore.Design: To enable migrations and database scaffolding.
Microsoft.IdentityModel.JsonWebTokens: For handling JWT tokens and token validation.
Microsoft.VisualStudio.Web.CodeGeneration.Design: For enabling code generation tools.
Swashbuckle.AspNetCore: To generate Swagger documentation for APIs.
Architecture Overview
The project consists of two main components that communicate with a shared library:

Logic of the App: This library is responsible for handling application logic and communicates with:

Logic of the Business: Implements business rules and domain-specific logic.
DTOs Library: Contains data transfer objects (DTOs) and mapping logic.
Logic of Access to Database:

This layer manages database operations and communicates with the business logic.
It uses DbContext to define entities and manage database migrations.
SQL Server is used to store and manage the application data.
Dependency Injection
All repositories and use cases are injected into the Program class of both the web application and API projects. 
This ensures proper dependency management and loose coupling between components.

Use of Interfaces
All use cases and repositories are managed via their respective interfaces. This approach adheres to the Dependency Inversion Principle, enhancing testability and maintainability.

DTOs Library
The DTOs Library is used to define data transfer objects (DTOs). 
These are specialized data structures used in use cases and views, rather than exposing entities directly. 
The library also includes mappers to transform data between entities and DTOs, ensuring a clear separation between layers.


                        +-------------------+
                        |   Frameworks &   |
                        |      Drivers     |
                        +-------------------+
                                ^
                                |
                                v
+-------------------+   +-------------------+   +-------------------+
|   Interface       |   |   Application     |   |   Enterprise      |
|   Adapters        |   |   Business Rules  |   |   Business Rules  |
+-------------------+   +-------------------+   +-------------------+
        ^                       ^                       ^
        |                       |                       |
        v                       |                       |
+-------------------+            |                       |
|   External        |            v                       v
|   Interfaces      +<--------- Use Cases          Entities
+-------------------+





The project, in general, lacks proper control in terms of exception handling. 
Many exceptions that occur are not being managed effectively within the code, which could lead to runtime issues. 
Additionally, it contains a significant amount of text in my native language(Spanish), which might need to be standardized.

It’s worth noting that this project was my first mvc proyect and this proyect developed in just one or two weeks, which may explain some of the current limitations and errors.
