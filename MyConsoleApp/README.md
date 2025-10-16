# Hellow Word .NET 8
[Hellow Word en 5 minutos](https://dotnet.microsoft.com/es-es/learn/dotnet/hello-world-tutorial/create)

1. Open command palette with CTRL+MAYÚS+P.
2. Write .NET: Select para ver los comandos que puede ejecutar con el Kit de desarrollo de C#.
3. Search and select .NET: New Project by create a new project.
4. Scroll down and select Console Application.
5. Choose the folder location where you want to save the project.
6. Name the project **MyConsoleApp** in the command palette when prompted.

## Console app of .NET 8. File structure:
- .sln file is the project file to ejecute the project, is the "solution"
- Folder with the same name, inside the files of the project
    - Program.cs: Default name of the project file, here you have the code to show "Hello, World!" in the console

## Run the app
- In VS Code, when you open the Program.cs file, you'll see a play icon in the top right corner to run the project. 

## Edit the code of Program.cs
You can add any code you need for your console application. ```DateTime.Now``` for Example, or anything else you need. 

# Add packages to the project (next learning paht module)
1- Check any package before install: https://www.nuget.org/packages/<package name>
- By all Dependencias review: Mantenaince, Licences, Size...
- Install using the CLI of .NET Core: with: ```dotnet add package <package name>```
- This will save the code in a memory caché that can use all projects.
- Then when finish, add the refences to the Debug or Release folders from the project
- All dependencies are referenced in the .csproj file.

** Humanizer package v.2.14.1 was installed 

### Whe will add a Fibonacci calculator to MyConsoleApp to test the debugger.
The Fibonacci sequence is a set of numbers starting with 0 and 1, and each subsequent number is the sum of the previous two. The sequence continues like this:
```
0, 1, 1, 2, 3, 5, 8, 13, 21...
```
We copi the code of the example that has a bug, and we'll check it in the debugger console. 