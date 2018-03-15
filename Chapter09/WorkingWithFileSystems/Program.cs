using System;
using static System.Console;
using System.IO;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkWithDrives();
            //WorkWithDirectorys();
            WorkWithFiles();
        }

        static void OutputFileSystemInfo(){
            WriteLine($"Path.PathSeperator: {Path.PathSeparator}");
            WriteLine($"Path.DirecotorySeperatorChar: {Path.DirectorySeparatorChar}");
            WriteLine($"Directory.GetCurrentDirectory: {Directory.GetCurrentDirectory()}");
            WriteLine($"Environment.CurrentDirectory: {Environment.CurrentDirectory}");
            WriteLine($"Environment.SystemDirectory: {Environment.SystemDirectory}");
            WriteLine($"Path.GetTempPath(): {Path.GetTempPath()}");
            WriteLine($"GetFolderPath(SpecialFolder):");
            WriteLine($"System {Environment.GetFolderPath(Environment.SpecialFolder.System)}");
            WriteLine($"ApplicationData: {Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}");
            WriteLine($"My Documents: {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
            WriteLine($"Personal: {Environment.GetFolderPath(Environment.SpecialFolder.Personal)}");
            
        }

        static void WorkWithDrives(){
            WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");
            WriteLine($"| Name                           |       Type |  Format |               Size |         Free space |");
            WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");

            foreach(DriveInfo drive in DriveInfo.GetDrives()){
                if(drive.IsReady){
                    WriteLine($"| {drive.Name, -30} | {drive.DriveType, -10} | {drive.DriveFormat, -7} | {drive.TotalSize,18:NO} | {drive.AvailableFreeSpace, 18:NO} |");
                }else{
                    WriteLine($"| {drive.Name, -30} | {drive.DriveType, -10} ");
                }
            }   
        }

        static void WorkWithDirectorys(){
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string[] directoryNames = {path, "SubFolder1", "Subfolder2"};
            
            WriteLine("Create Dir if it dosent exist");
            string dirPath = Path.Combine(directoryNames);
            if(!Directory.Exists(dirPath)){
                Directory.CreateDirectory(dirPath);
            }
            WriteLine("Confirm the dir exist");
            ReadLine();
            WriteLine("Deleting it");
            Directory.Delete(dirPath);
        }

        static void WorkWithFiles(){
            WriteLine("Create File");
            string pathDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Workspace", "DotNet" ,"Test");
            string path = Path.Combine(pathDir, "Datei.txt");
            
            WriteLine("Write to File");
            string pathBackup = Path.Combine(pathDir, "Backup", "DateiBackup.txt");
            StreamWriter textWriter  = File.CreateText(path);
            textWriter.WriteLine("Helldfdo");
            textWriter.Close();
            try{
                WriteLine("Copy File to Backup");
                File.Copy(path, pathBackup, true);
            }catch(System.UnauthorizedAccessException ex){
                WriteLine(ex.GetType());
            }
            WriteLine("rm File");
            File.Delete(path);

            WriteLine("Read File from Backup");
            StreamReader read = File.OpenText(pathBackup);
            string line = read.ReadLine();
            read.Close();
            WriteLine($"read Line {line}");
            
            WriteLine("\nFile Information:");
            WriteLine($"File Name: {Path.GetFileName(pathBackup)}");
            WriteLine($"File Name without Extension: {Path.GetFileNameWithoutExtension(pathBackup)}");
            WriteLine($"File Extension: {Path.GetExtension(pathBackup)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            //Create TempFile and Return the name
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            var info = new FileInfo(pathBackup);

            WriteLine("\nBackupFile");
            WriteLine($"size in bytes: {info.Length} ");
            WriteLine($"created: {info.CreationTime}");
            WriteLine($"last modified: {info.LastWriteTime}");
            WriteLine($"Is read only: {info.IsReadOnly}");
        }
    }
}
