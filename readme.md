# Your Project Name

A brief description of your project, what it does and why it exists.

## Getting Started

These instructions will get the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install and how to install them:

- .NET Core 7.0
- Any other third-party libraries or software

In JetBrains Rider navigate to File > Setting > Build, Execution, Deployment > .NET Core and select .NET Core 7.0 SDK.

### Installation

A step-by-step series of how to get a development environment running:



1. Download repo.
2. In ./WebApplication1/appsettings.json `Firebase::KeyPath`  set path for Firebase json key-file. Not sure if filname will be the same. Commented path is for dockerized app. 
3. ./Infrastructure/script.sql - execute script on local postgres databaase.
4. Connection string is default(port 5432, u:postgres, p:postgres)
5. ./WebApplication1 = in this path use command `docker run`, it runs the application on port 5000
6. http://localhost:5000/swagger/index.html - Swagger link
7. Authorize with idToken gathered from: https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyC6NQgwckIiz7L5S7EVLHidsO8IByB3y_E
8. Trigger CreateUser to create logged user in database.


### EF Migrations
To use below commands you must be in Infrastructure folder.
1. Create configuration for Entity. If base class use Attributes, otherwise use FluentConfiguration. 
2. use `dotnet ef migrations add YourMigrationName` to create new Migration
3. use `dotnet ef database update --startup-project ../WebApplication1`
4. if your migration was faulty then use `dotnet ef migrations remove --startup-project ../WebApplication1`


