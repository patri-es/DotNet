# DotNet
This repository is a review of .net technologies to get up to speed and clarify concepts.

I will started following the complete route of Microsoft Learning: 
[Develop Apps with .NET](https://learn.microsoft.com/es-es/collections/2md8ip7z51wd47)

## 1. To get started you'll need: 
- [Install SDK of .NET 8 ](https://dotnet.microsoft.com/es-es/download)
- [Install C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

### MyConsoleApp, first part of the Learning path.
*See the folder ***MyConsoleApp***
- To run this project, move the curor of the folder into the project folder ```cd MyConsoleApp``` and execute this comand: ```dotnet run``` 

## 2. [DotNet Dependencies](https://learn.microsoft.com/es-es/training/modules/dotnet-dependencies/)

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

3. Manage dependency package updates: 
- What type of update?: small bug fix, added new feature, break the code? this is indicated by  [Semantic versioning](https://semver.org/lang/es/).
- You can configure what type of updates you receive, only the type you're interested in. This is a recommended approach.
- Security problems


###  using [Semantic versioning](https://semver.org/lang/es/)
1. Major version: the first number (X.0.1) only change with importants changes in the code. You may need to rewrite some the code with this new update.
2. Minor version: the number in the middle (1.X.0) this minds that was added a new feature. The code should be working, usually is safe to acept the update.
3. Revision version: the number more in the right (1.0.X) This is a change that apply a fix of some bug. It should be safe to accept the update.

### Configuring the project file for upgrade
By big or old projects, you can configure the updates accepts, including or excluding some types of version as major or minor version appliyng rules. 
Examples: 
```XML
<!-- Accepts any version 6.1 and later. -->
<PackageReference Include="ExamplePackage" Version="6.1" />

<!-- Accepts any 6.x.y version. -->
<PackageReference Include="ExamplePackage" Version="6.*" />
<PackageReference Include="ExamplePackage" Version="[6,7)" />

<!-- Accepts any later version, but not including 4.1.3. Could be
     used to guarantee a dependency with a specific bug fix. -->
<PackageReference Include="ExamplePackage" Version="(4.1.3,)" />

<!-- Accepts any version earlier than 5.x, which might be used to prevent pulling in a later
     version of a dependency that changed its interface. However, we don't recommend this form because determining the earliest version can be difficult. -->
<PackageReference Include="ExamplePackage" Version="(,5.0)" />

<!-- Accepts any 1.x or 2.x version, but not 0.x or 3.x and later. -->
<PackageReference Include="ExamplePackage" Version="[1,3)" />

<!-- Accepts 1.3.2 up to 1.4.x, but not 1.5 and later. -->
<PackageReference Include="ExamplePackage" Version="[1.3.2,1.5)" />
```
### Search and update obsolete packages
```dotnet list package --outdate``` shows obsolete packages, this command heps to check the recients versions, and shows three categories: 
- Requested: Specified version or version range.
- Resolved: Actual version installed in the project.
- Lasted: Latest version available for updating from NuGet.

It's recomended execute the commands in this order: 
1. ```dotnet list package --outdated``` check the version list
2. ```dotnet add package <name> (optional: --version <number or range>)``` to update that you need, verified with the previous command.

- You can check prerelease also using ```dotnet list package --outdate --include-prerelease``` : ```dotnet add package Humanizer --prerelease```

#### Update approach
If you work in an enterprise environment, it is recommended that you carefully consider the approach related to the types of updates you accept.

Related links:
- [documentación del CLI de .NET](https://learn.microsoft.com/es-es/dotnet/core/tools/)
- [documentación de NuGet ](https://learn.microsoft.com/es-es/nuget/)
