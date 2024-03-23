# E-Commerce Project

This project aims to develop an application in the E-Commerce domain using N-tier Architecture and adhering to SOLID principles. The goal of the project is to ensure users have a functional and interactive experience.

## SOLID Principles

In object-oriented programming, SOLID principles are design patterns used to make software design more understandable, flexible, and sustainable.

1. Single Responsibility Principle,
2. Open/Closed Principle
3. Liskov Substitution Principle
4. Interface Segregation Principle
5. Dependency Inversion Principle

For more detailed information [GitHub Pages](https://github.com/sonmezhakan/SOLID/tree/master).

## NTier Architecture

NTier Architecture ensures the development of a project by dividing its responsibilities through layers. Each layer has its own set of responsibilities, making the application sustainable, extensible, and more suitable for teamwork. By breaking down our code into smaller structures, we enhance maintainability and updatability. Layers created in the project:

1. Business Layer(BLL)
2. Data Layer(DAL)
3. Entity Layer
4. Presentation Layer
5. Inversion Of Control(IoC)
6. Common

### 1.Business Layer(BLL)

The user's requests are implemented in conjunction with the Business Layer (BLL). This layer encapsulates the fundamental business logic of the application.

### 2.Data Layer(DAL)

The Data Layer enables us to access the database and perform various operations related to it.

### 3.Entity Layer

This layer facilitates the association of objects used within the application with tables in the database. The Entity Layer is generally supported by Object-Relational Mapping (ORM) tools.

ORM serves as an interface handling the differences between objects and relational databases. It maps the data in the database to objects, managing the relationships between these objects.

### 4.Presentation Layer

This layer interacts with users and involves creating the visual interfaces of applications using front-end technologies.

### 5.Inversion Of Control(IoC)

IoC (Inversion of Control) is a principle aimed at minimizing the dependencies between classes, ensuring a loose coupling. An IoC layer has been created for this principle.

### 6.Common

The Common layer is utilized as a shared layer, containing common functionalities used across different layers.

In addition to the basic layers mentioned above, depending on your project, you can create additional layers to make the project more extensible.

## Technologies
- .Net
- MsSql
- Asp.Net
- AutoMapper
- Bootstrap
- Jquery

## Libraries

- [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/)
- [Microsoft.AspNetCore.Identity.EntityFramework](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/)
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/)
- [Microsoft.Extensions.Configuration.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions/)
