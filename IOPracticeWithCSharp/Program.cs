using System;
using System.IO;

namespace IOPracticeWithCSharp
{
  class Program
  {
    static void Main(string[] args)
    {
      /*
       * 1. Using File type static method.
       */

      var testPath = "/Users/frederickjavalera/Downloads/test.txt";
      var test2Path = "/Users/frederickjavalera/Downloads/test2.txt";
      // Copy a file on a Mac. Copy file test.txt to downloads directory to test.
      try
      {
        File.Copy(testPath, test2Path, true);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
      }

      // Delete a file (copy).
      try
      {
        File.Delete(test2Path);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
      }

      // Check if file exists.
      try
      {
        if (File.Exists(testPath))
        {
          Console.WriteLine("File exists\n");
        }
        else
        {
          Console.WriteLine("File doesn't exist.\n");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
      }

      // Read all of the text in the file and write to console.
      try
      {
        var content = File.ReadAllText(testPath);
        Console.WriteLine(content);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
      }

      /*
       * 2. Using FileInfo type method.
       */

      var fileInfo = new FileInfo(testPath);

      // Copy
      fileInfo.CopyTo(test2Path);

      // Delete copy.
      var fileInfo2 = new FileInfo(test2Path);
      fileInfo2.Delete();

      // Check if file exists
      if (fileInfo.Exists)
      {
        // Do something.
      }

      // Read all of the text in the file and write to console.
      // Uses FileStream. Lesson forthcoming.

      /**
       ** Working with directories.
       **/

      /*
       * 1. Using Directory static method.
       */

      var tempDirectoryPath = "/Users/frederickjavalera/Downloads/tempDirectoryFolder";
      var containerDirectory = "/Users/frederickjavalera/Downloads/";

      // Create a new directory.
      Directory.CreateDirectory(tempDirectoryPath);

      // Find all pdf files in Downloads folder. For all files use "." instead of "*.pdf".
      var files = Directory.GetFiles(containerDirectory, "*.pdf", SearchOption.AllDirectories);
      foreach (var file in files)
      {
        Console.WriteLine(file);
      }

      // Find all directories within a directory.
      var directories = Directory.GetDirectories(containerDirectory, "*.*", SearchOption.AllDirectories);
      foreach (var directory in directories)
      {
        Console.WriteLine(directory);
      }

      // Check if directory exists.
      if (Directory.Exists(containerDirectory))
      {
        // Do something.
      }

      /*
       * Using DirectoryInfo type method.
       */
      var directoryInfo = new DirectoryInfo(containerDirectory);

      // Retrieves all files in the directory.
      var files2 = directoryInfo.GetFiles();
      foreach (var file in files2)
      {
        Console.WriteLine(file);
      }

      // Retrieves all directories with the directory.
      var directories2 = directoryInfo.GetDirectories();
      foreach (var directory in directories2)
      {
        Console.WriteLine(directory);
      }

      /**
       ** Working with Paths.
       **/
      var path = "/Users/frederickjavalera/Downloads/test.txt";

      // Bad way of getting extension of file.
      var dotIndex = path.IndexOf('.');
      var extension = path.Substring(dotIndex);
      Console.WriteLine($"Extension, bad way: {extension}");

      // Better way using Path class.
      Console.WriteLine($"Extension, better way: {Path.GetExtension(path)}");

      // Get file name.
      Console.WriteLine($"File name: {Path.GetFileName(path)}");

      // Get file name without extension.
      Console.WriteLine($"File name without extension: {Path.GetFileNameWithoutExtension(path)}");

      // Get directory name.
      Console.WriteLine($"Directory name: {Path.GetDirectoryName(path)}");
    }
  }
}