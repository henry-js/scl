using System.CommandLine;
using System.Text;

var fileOption = new Option<FileInfo?>(
    "--file",
    "The file to read and display on the console.");

var rootCommand = new RootCommand("Sample app for System.CommandLine");
rootCommand.AddOption(fileOption);

rootCommand.SetHandler((file) => ReadFile(file!), fileOption);

return await rootCommand.InvokeAsync(args);

static void ReadFile(FileInfo file)
{
    File.ReadAllLines(file.FullName).ToList()
        .ForEach(Console.WriteLine);
}