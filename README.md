# DotNet
This repository is a review of .net technologies to get up to speed and clarify concepts.

I will started following the complete route of Microsoft Learning: 
[Develop Apps with .NET](https://learn.microsoft.com/es-es/collections/2md8ip7z51wd47)

## To get started you'll need: 
- [Install SDK of .NET 8 ](https://dotnet.microsoft.com/es-es/download)
- [Install C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

### MyConsoleApp, first part of the Learning path.
*See the folder ***MyConsoleApp***
- To run this project, move the curor of the folder into the project folder ```cd MyConsoleApp``` and execute this comand: ```dotnet run``` 

## [DotNet Dependencies](https://learn.microsoft.com/es-es/training/modules/dotnet-dependencies/)

### Add packages to the project (next learning paht module)
1- Check any package before install: https://www.nuget.org/packages/<package name>
- By all Dependencias review: Mantenaince, Licences, Size...
- Install using the CLI of .NET Core: with: ```dotnet add package <package name>```
- This will save the code in a memory caché that can use all projects.
- Then when finish, add the refences to the Debug or Release folders from the project
- All dependencies are referenced in the .csproj file.


2. Main commands for working with packages:
- ```dotnet tool install <name of tool>``` to install tools
- ```dotnet new -i <name of package>``` to install templates
- ```dotnet add package <name of package>``` to install dependencies
- ```dotnet list package``` to list the project's dependencies 
- ```dotnet list package --include-transitive``` to list all the project's dependencies and subdependencies
- ```dotnet remove package <name of package>``` to remove dependencies
- ```dotnet restore``` to install all dependencies specified in the .csproj file when creating or cloning a project. This is generally not necessary, as the restore is performed using the commands: ```new```, ```build``` y ```run```