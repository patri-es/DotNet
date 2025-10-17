using System.IO;
using System.Collections.Generic;

// // // ----------1-  This is a simple example with a simple route in the folder structure... Using static route
// var salesEasyFiles = FindEasyFiles("stores");
// foreach (var file in salesEasyFiles)
// {
//     Console.WriteLine(file);
// }
// // function with simple route that search and return de files in a folder.
// IEnumerable<string> FindEasyFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         // The file name will contain the full path, so only check the end of it
//         if (file.EndsWith("sales.json"))
//         {
//             salesFiles.Add(file);
//         }
//     }
//     return salesFiles;
// }

// // // -----------2- Iterate through directories and get the current directory... using static route
// // IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

// // Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
// // foreach (var dir in listOfDirectories)
// // {
// //     Console.WriteLine(dir);
// // }

// // // ----------3- Now with complete routes: 
// // function with simple route that search and return de files in a folder.
// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         // to search by extension
//         var extension = Path.GetExtension(file);
//         if (extension == ".json")
//         {
//              salesFiles.Add(file);
//         }
//     }
//     return salesFiles;
// }


// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");
// var salesFiles = FindFiles(storesDirectory);

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// // - 4 Sumary:
var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
// here we make sure than create the directory if not exist
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);

// this will write the new file with totals
File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // to search by extension
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
             salesFiles.Add(file);
        }
    }
    return salesFiles;
}
