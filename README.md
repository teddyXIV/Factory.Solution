# Factory

####  An MVC web application to help a fictional factory manage engineers and machines.

#### By Teddy Peterschmidt

## Technologies Used

* C#
* .NET 6 SDK
* Entity Framework Core

## Description

This application allows the user to manage the factory's engineers and machines through the following functionality: 
* Adding to a list of engineers 
* Editing engineer information
* Deleting engineers
* Adding licenses for specific machines to engineers
* Adding to a list of machines
* Editing machine details
* Deleting machines
* Record inspections of machines
* Record accidents 

## Setup/Installation Requirements

* Clone this repository.
* If needed, download and configure MySQL Workbench for your operating system by following the instructions in [this lesson.](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) 
* Navigate to the production directory Factory.
* Within the production directory "Factory", create a new file called `appsettings.json`.
* Within `appsettings.json`, put in the following code, replacing the `database`, `uid`, and `pwd` values with your own username and password for MySQL.
```json 
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database={YOUR_DATABASE_NAME_HERE};uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
* In the command line, run "dotnet restore" to download and install packages.
* In the command line run "dotnet ef database update" to update your database.
* In the command line, run the command "dotnet run" to compile and execute the application.
* Optionally, you can run "dotnet build" to compile this application without running it.

## Known Bugs

* Unknown at this time.

## License

[MIT License](./LICENSE)