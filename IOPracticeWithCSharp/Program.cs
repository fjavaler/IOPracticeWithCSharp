using System;
using System.IO;

namespace IOPracticeWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Using File type static method.
             */

            var testPath = "/Users/frederickjavalera/Downloads/test.txt";
            var test2Path = "/Users/frederickjavalera/Downloads/test2.txt";
            // Copy a file on a Mac. Copy file test.txt to downloads directory to test.
            try
            {
                File.Copy(testPath, test2Path, true);
            }
            catch(Exception ex)
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
                if(File.Exists(testPath))
                {
                    Console.WriteLine("File exists\n");
                }
                else
                {
                    Console.WriteLine("File doesn't exist.\n");
                }
            }
            catch(Exception ex)
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
             * Using FileInfo type method.
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
        }
    }
}