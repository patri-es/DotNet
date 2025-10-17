using System.IO;
using System.Collections.Generic;

// This is a simple example with a simple route in the folder structure... 
var salesEasyFiles = FindEasyFiles("stores");
foreach (var file in salesEasyFiles)
{
    Console.WriteLine(file);
}
// function with simple route that search and return de files in a folder.
IEnumerable<string> FindEasyFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }
    return salesFiles;
}

