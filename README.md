# ProductShop
Main goal of application is simple - fetch products and update one single product. 

# Technical specification

This is a .NET WebApi application written in latest [LTS](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) version - `.NET 6`.  
It's desined using Domain-Driven-Design to properly separate layers of application: domain, infrastructure, application, presentation

### Main technologies/libraries used for this project:  

**CQRS & MediatR** - as main design pattern for communication between modules.  
**FluentValidatoin** - for defining validation pipelines to support better input validation.  
**EntityFramework** - main ORM to support application <-> DB communication.  
**Serilog** - flexible logger.   
**Swagger & Swashbuckle** - generate and view API documentation.  
**xUnit** - main test tool.  
**FluentAssertions** -  to write more expressive and more flexible tests.  
**Moq** - mocking library, because we need it sometimes.   

## How to run

In all cases you need to clone this repository first: 

`git clone https://github.com/FerencDocsa/ProductShop.git`  

### Docker
[Docker](https://www.docker.com/) need to be installed to run with this method   
To run this project in a docker container, navigate to the root folder of the project and type in the following command:

`docker-compose up --build`

After the container is up and running you should be able to access application on
`http://localhost:5000`

### Dotnet CLI
CLI is a part of [.NET](https://dotnet.microsoft.com/en-us/download)   
Open the terminal in the root folder then navigate to \Presentation\ProductShop.WebAPI\ and run command

`dotnet run`  

Application will be avaliable on   
`https://localhost:7252/`

### IDE 
Navigate to root folder of the project and open `.sln` file with IDE of your choice (it should support .NET 6). 
Build and run your project, swagger page should open automatically 

**Note 1:** For all non-docker options you need to update `connectionString` in `appsettings.json` and/or `appsettings.Development.json` to your MSSQL DB Connection!   
**Note 2:** Since it's a WebAPI it doesn't have any UI, but you can access `/swagger` to view API documentation.


### Usage and available endpoints

#### V1 Endpoints
Swagger is enabled in prod by purpose, you can view all avaliable endpoints at
`http://localhost:port/swagger/index.html`

| Method        | Route           | Purpose  |
| ------------- |:-------------| :-----|
| GET      | /api/v1/Products/{id} | Returns a Product for specified ID |
| GET      | /api/v1/Products/ | Returns  all products |
| PUT      | /api/v1/Products/{id} | Updates product with specified ID with new description |

#### V2 Endpoints
| Method        | Route           | Purpose  |
| ------------- |:-------------| :-----|
| GET      | /api/v2/Products | Returns all products, supports paging, searching, ordering and sorting |

To access this endpoints after application start use [Postman](https://www.postman.com/) (recomended) 


### Testing
This project contains Unit and Integration tests.   
It is prefered to run them using IDE of your choice, simple navigate to `Tests` in Solution explorer, chose Unit/Integration tests and click "Run Tests" (can vary depending on your IDE). Fingers crossed - all of them should be green after execution.

## Misc Info

This repository has `GitHub Actions` configured, so each time there is a PR or Commit it automatically runs a build&test to ensure that changes are not breaking the codebase. Pipeline could also be extended to allow CD, for example Azure deployment.

There is 99.9% chance that there are several places in code that could use additional validation, logging, exception handling etc but i tried to implement them in most notable places and to showcase best of my knowledge.

