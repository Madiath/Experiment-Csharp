Paquetes NuGet necesarios

- Microsoft.AspNetCore.Authentication.JwtBearer: Para manejar la autenticación con JSON Web Token (JWT).
- Microsoft.EntityFrameworkCore: Para usar Entity Framework Core y administrar el acceso a la base de datos.
- Microsoft.EntityFrameworkCore.Design: Para habilitar migraciones y scaffolding de base de datos.
- Microsoft.IdentityModel.JsonWebTokens: Para manejar tokens JWT y su validación.
- Microsoft.VisualStudio.Web.CodeGeneration.Design: Para habilitar herramientas de generación de código.
- Swashbuckle.AspNetCore: Para generar documentación Swagger de las APIs.

------------------------------------------------------------

Arquitectura – Descripción General

El proyecto consta de dos componentes principales que se comunican con una librería compartida:

Lógica de la Aplicación
Esta librería se encarga de manejar la lógica de la aplicación y se comunica con:
- Lógica de Negocio: Implementa reglas de negocio y lógica específica del dominio.
- Librería de DTOs: Contiene Data Transfer Objects (DTOs) y lógica de mapeo.

Lógica de Acceso a la Base de Datos
- Administra las operaciones de base de datos y se comunica con la lógica de negocio.
- Utiliza DbContext para definir entidades y gestionar migraciones.
- SQL Server se emplea como gestor de base de datos para almacenar y administrar los datos de la aplicación.

------------------------------------------------------------

Inyección de Dependencias
Todos los repositorios y casos de uso se inyectan en la clase Program de los proyectos WebApp y API.
Esto garantiza una correcta gestión de dependencias y un bajo acoplamiento entre los componentes.

------------------------------------------------------------

Uso de Interfaces
Todos los casos de uso y repositorios se gestionan mediante sus interfaces respectivas.
Este enfoque sigue el Principio de Inversión de Dependencias (DIP), lo que mejora la testabilidad y la mantenibilidad.

------------------------------------------------------------

Librería de DTOs
La librería de DTOs se utiliza para definir objetos de transferencia de datos (Data Transfer Objects).
- Estos son estructuras especializadas que se usan en los casos de uso y vistas, en lugar de exponer directamente las entidades.
- También incluye mapeadores para transformar datos entre entidades y DTOs, asegurando una separación clara entre capas.

------------------------------------------------------------

Diagrama de Capas (visión simplificada)

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

------------------------------------------------------------

Observaciones

- El proyecto, en general, carece de un control adecuado en el manejo de excepciones.
  Muchas excepciones no están siendo gestionadas de forma efectiva en el código, lo que podría provocar errores en tiempo de ejecución.

- Cabe destacar que este fue mi primer proyecto MVC, desarrollado en solo una o dos semanas, lo que puede explicar algunas de sus limitaciones y errores actuales.
