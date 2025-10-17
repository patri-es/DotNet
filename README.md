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

## 3. Interactively debug .NET applications with the Visual Studio Code debugger
As any programming knows, you have to debug your code to find bugs and fix they. 
- Do click over the left of the number line in VS Code to add a new point to interruptus the execution of the code. 
- Do right click in the same area or over one point that already have, to define a condition for this point, this will stopped the execution only when this line is executed and when the condition is met.

- To start the debug, you need select the debug option in the play icon of any .net file. (Program.cs in our example), them you wil see the pannel with options to continuous line by line...

- You can create also a **launch.json** file if you need. ***.vscode/launch.json***

### Viewing and Editing Variable State
Debugging, variables are dilsplayed organized by scope:
- Local variables (accesible withim the current scope, usually the current function)
- Global variables (accesible from anywhere in the program. System objects from JS also included)
- Closure variables (accesible from the current closure, if one exists. Combine the local scope of a function with the scope of the outer function to which belongs)

You can view all the objects properties, and change the value of a variable  on the fly by double-clicking on it.

### [Call Stack](https://learn.microsoft.com/es-es/visualstudio/debugger/how-to-use-the-call-stack-window?view=vs-2022)
Represents the sequence of function calls. It's useful for finding the origin of an exception for example.

- You can select the launch console between ***console*** and ***integratedTerminal***, for that you need add in the launch.json:

```JSON
"console": "internalConsole",
    or
"console": "integratedTerminal",
```
- We add a Fibonacci calculator to MyConsoleApp to test the debugger.

### Logging and tracing in .NET applications
The tracing is a way to monitorized the execution of your application while it's working. You can add tracing and debugging instrumentation to your .NET application as you develop it. You can also use that intrumentation while developing the application and after you deploy it.

- Creating logs allows for detailed "post morten" review over long periods of time.
#### Writing information to output windows
In applications of .NET with user interfaces (not Console App), we have ```System.Console``` which records messages "in the background". Those messages can shows in output window of the IDE (VS or VS Code). And can generate a log as logcat in Android. As result, you must to be carefull using ```System.Console.WriteLine```.

For that, you have others options to log and trace the application:

- ```System.Console``` 
    - alwais available, alwais write in the console
    - Usefful by the information neede to see the client
    - Usually by the temporal debbugger, and not checked in the code control.
- ```System.Diagnostics.Trace``` 
    - available only when ```TRACE``` is defined
    - Writes to associated listeners, by default: DefaultTraceListener
    - Use it to create traces that will be available in most compilations.
- ```System.Diagnostics.Debug```
    - available only when ```DEBUG``` is defined (in debugger mode)
    - Write in associate debugger
    - Use it to create traces that will only be available in debugger compilations.

```C#
Console.WriteLine("This message is readable by the end user.");
Trace.WriteLine("This is a trace message when tracing the app.");
Debug.WriteLine("This is a debug message just for developers.");
```

#### TRACE and DEBUG constants
- As default, DEBUG is defined when the app is executed with Debug mode. To controll it, you can add ***DefineConstants*** in the **.csproj** file. 

This example shows the configuration to Debug, Releace and to activate TRACE:
``` XML
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <DefineConstants>DEBUG;TRACE</DefineConstants>
</PropertyGroup>
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|AnyCPU'">
    <DefineConstants>TRACE</DefineConstants>
</PropertyGroup>
```
- If you don't have a debugger asociated, you'll need to configurate a listener of tracer as ```dotnet-trace```
-Yo can add conditions by tracer and debug with ```WriteIf``` and ```WriteLineIf```
```C#
bool errorFlag = false;  
System.Diagnostics.Trace.WriteIf(errorFlag, "Error in AppendData procedure.");  
System.Diagnostics.Debug.WriteIf(errorFlag, "Transaction abandoned."); 
```

#### Checking that certain conditions exist
- **Assert** test a condition that you specify as argument of instruccion ```Assert```. If the condition is ***True***, don't happend anything, if it's ***False***, shows an assert error, in this case if you are debugging, provoque an exception. 
- You can use **Assert** in Debug and Trace (in **System.Diagnostics** NameSpace)
- The Debug methods aren't not included in the release version, so don't bloat or slow down the final version of the code.

```C#
int IntegerDivide(int dividend, int divisor)
{
    Debug.Assert(divisor != 0, $"{nameof(divisor)} is 0 and will cause an exception.");

    return dividend / divisor;
}
```
- Be careful when including this Debug.Assert, verify that the results don't change if you remove the line, as this line will not be included in the release version.

Related links: [Debug with VS Code](https://code.visualstudio.com/docs/debugtest/debugging), [Tutorial: Debug with VS Code](https://learn.microsoft.com/es-es/dotnet/core/tutorials/debugging-with-visual-studio-code)



## 4. Working with files and directories in .NET application
### File System (System.IO NameSpace): 
System.IO has types integrated that allow interact with files and directories using GET and SET, searching, writing and readding. 

- Listing all directories: ```Directory.EnumerateDirectories ```
```C#
IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

foreach (var dir in listOfDirectories) {
    Console.WriteLine(dir);
}

// Outputs:
// stores/201
// stores/202
```
- Listing all files from a directory: ```Directory.EnumerateFiles ```
```C#
IEnumerable<string> files = Directory.EnumerateFiles("stores");

foreach (var file in files)
{
    Console.WriteLine(file);
}

// Outputs:
// stores/totals.txt
// stores/sales.json
```
- Both functions have a overload that allow a paremeter to specify search pattern. Another overload is to specify get all recursive folders: ```Directory.allFilesInAllFolders``` and ```Directory.EnumerateFiles ```
```C#
// Find all *.txt files in the stores folder and its subfolders
IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles("stores", "*.txt", SearchOption.AllDirectories);

foreach (var file in allFilesInAllFolders)
{
    Console.WriteLine(file);
}

// Outputs:
// stores/totals.txt
// stores/201/inventory.txt
```

- I cloned and created the folder ***mslearn-dotnet-files*** to follow the example. Check it for more information.

- If you use .NET 6 or older, It's needed to add those Name Spaces. The rest, have automatily included in the property group ***ImplcitUsings*** :
```C#
using System.IO;
using System.Collections.Generic;
```

### Special Directories
Not all system has this concept. Ussually they are by things as Main folder of the User, temporaly files....
For that, .NET has the enumeration: **System.Environment.SpecialFolder** that specify const by get the routes of those specials system folders. 
```C#
//This get "Documents" in windows or "Home" in linux
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
```

###  Path class: 
.NET have included a Class for that: **System.IO.Path**. This class don't check if the route exit or not. They are concepts routes, not real.
- Access Routes. This class has a input to get **the separator chard** \ or / that its depend of the operative system:
```C#
Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");

// returns:
// stores\201 on Windows
//
// stores/201 on macOS
``` 
Here are some useful methods of this class:
- Routes combines. You can use Path to create automatily the correct route:
```C#
Console.WriteLine(Path.Combine("stores","201")); // outputs: stores/201
```
- You can request the extension of a file with **GetExtension** 
```C#
Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json
```
- To know more information about a file or directory use: **FileInfo** or **DirectoryInfo**.
```C#
string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

FileInfo info = new FileInfo(fileName);

Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
```

### Directory and file class:
They are by search, create, move, copy, rename, remove or modify. 
- ```Directory.CreateDirectory``` to make sure than the directory exist, if not, create it:
```C#
Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));
```
- ```Directory.Exists``` to check than the directory exist:
```C#
bool doesDirectoryExist = Directory.Exists(filePath);
```
- ```File.WriteAllText``` to create and write a file, if is already exist, it will be overwrites:
```C#
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
```

### Write and read files:
- ```File.ReadAllText``` to read the file
```C#
File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
```
- As in the example are .json files, to analize the datas, we need add ```Json.NET``` package from NuGet: ```dotnet add package Newtonsoft.Json``` and add the reference in the Program.cs file ```using Newtonsoft.Json;```