# Pigwarts School of Magic and Trickery Registrar

#### C#, MVC applications, mySQL, many-to-many relationships

#### By Shannon Lee, Colin Chapman, and Salim Mayam

#### _Table of Contents_

1. [Description](#description)
2. [Technologies Used](#technologies)
3. [Setup/Installation Requirements](#setup)
4. [Schema](#schema)
5. [Known Bugs](#bugs)
6. [License](#license)
7. [Contact Information](#contact)


## Description <a id="description"></a>

This is an MVC application made using C#, .NET5, MySQL, and Entity for a fictional school's registar. This project demonstrates understanding of MVC, CRUD functionality, use of Entity, database basics, one-to-many and many-to-many relationships. It allows the user to create courses, students, and departments. The students may enroll in many different courses. Each course or student is associated with a single department.

## Technologies Used <a id="technologies"></a>

* C#
* .NET 5
* MSBuild
* MSTest
* Entity
* MySQL
* git


## Setup/Installation Requirements <a id="setup"></a>

Setup requirements
* Make sure that .NET Software Development Kit 5 and MySQL have been installed to your local machine.

Installation
* Clone this repository to your machine `$ git clone https://github.com/shanole/Registrar.Solution`
* In the terminal, navigate to the project directory `$ cd Registrar.Solution/UniRegistrar`
* Create `appsettings.json` file in `/UniRegistrar` directory with the following code:
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<YOUR DATABASE NAME>;uid=root;pwd=<YOUR PASSWORD HERE>;"
  }
}
```
* Create local database from migration with `dotnet ef database update`
* Compile code by running command `$ dotnet build`
* Run program with command `$ dotnet run` to open webpage on your preferred browser at `http://localhost:5000`

## Schema <a id="schema"></a>

![schema design](https://github.com/shanole/Registrar.Solution/blob/main/schema.png?raw=true)

## Known Bugs <a id="bugs"></a>
* In Search route for courses (`searches/courses`), the message "No courses match your search query" displays before a search has been made.
* Let us know if you have identified any more!

## License <a id="license"></a>
*[MIT](https://choosealicense.com/licenses/mit/)*

Copyright (c) 2021 Colin Chapman, Shannon Lee, and Salim Mayam

## Contact Information <a id="contact"></a>
**_Shannon Lee [mailto](mailto:shannonleehj@gmail.com)_**
**_Colin Chapman [mailto](mailto:cchap14@gmail.com)_**