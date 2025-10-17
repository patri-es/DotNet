using System.Text.Json;
//using Newtonsoft.Json;

// using System.IO;
// using System.Collections.Generic;
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

// // // - 4 Sumary:
// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");

// var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
// // here we make sure than create the directory if not exist
// Directory.CreateDirectory(salesTotalDir);   

// var salesFiles = FindFiles(storesDirectory);

// // this will write the new file with totals
// File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

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

// 5- Reading datas and write sumary
//var salesData =  JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// VS Code shows error, I don't understand wy. I ask to the IA, and change my using reference of Newtonsoft.Json, and the code like this: 
// var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

// record SalesData (double Total);

// double CalculateSalesTotal(IEnumerable<string> salesFiles)
// {
//     double salesTotal = 0;

//     // Loop over each file path in salesFiles
//     foreach (var file in salesFiles)
//     {      
//         // Read the contents of the file
//         string salesJson = File.ReadAllText(file);

//         // Parse the contents as JSON
//         SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

//         // Add the amount found in the Total field to the salesTotal variable
//         salesTotal += data?.Total ?? 0;
//     }

//     return salesTotal;
// }

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


// var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// var salesData =  JsonSerializer.Deserialize<SalesTotal>(salesJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
// if (salesData != null)
// {
//     Console.WriteLine(salesData.Total);
//     // override the file 
//     //File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", salesData.Total.ToString());
//     // Add new line to the file
//     File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{salesData.Total}{Environment.NewLine}");

// }


// class SalesTotal
// {
//     public double Total { get; set; }
// }


////----------------------------------------------
//using Newtonsoft.Json; 

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonSerializer.Deserialize<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}

record SalesData (double Total);