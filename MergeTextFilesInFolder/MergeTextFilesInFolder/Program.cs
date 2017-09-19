using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTextFilesInFolder
{
    class Program
    {


        static void Main(string[] args)
        {



            string fileTypeExtension = FileTypeToMerge();
            string folderPath = FolderPathWithFilesToMerge();
            string mergePath = MergeFilesPath();
            //deletes any previous merged file to avoid exceptions being thrown
            DeleteMergedFile(mergePath);

            string[] fileNamesArray = FileNamesToArray(folderPath,fileTypeExtension);
            //string[] fileNamesArray = Directory.GetFiles(folderPath, "*" + fileTypeExtension);
            //test path here, to paste right click top of console and select/edit/paste
            // C:\Users\Andro\Desktop\Test Folder for VS project\
            // C:\Users\Andro\Desktop\Test Folder for VS project\MergedFile.txt


            

            try
            {
                Console.WriteLine("You picked the file type " + fileTypeExtension);
                Console.WriteLine("All the files that match your folder and selection are:");
                //Display all files
                foreach (string name in fileNamesArray)
                {
                    //writes each file name out for debugging purposes
                    //Console.WriteLine(Path.GetFileName( name));


                    string line = String.Empty;
                    using (StreamReader reader = new StreamReader(name))
                    {
                        //reads each line
                        line = reader.ReadToEnd();

                        using (StreamWriter writer = new StreamWriter(mergePath))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    //Puts all text together
                    Console.WriteLine(line);
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                //throw e;
                Console.WriteLine("an error has occured: '{0}' ", e.Message);
            }

            Console.ReadLine();
        }
        //request user to type in what file type they want to merge
        static string FileTypeToMerge()
        {

            Console.WriteLine("Define your file type to merge , example : .xml or .txt");
            string fileTypeExtension = Console.ReadLine().ToString();
            return fileTypeExtension;
        }
        //request user to type in the folder path where the files are to merge
        static string FolderPathWithFilesToMerge()
        {
            //Console.WriteLine("Give a valid path to the folder.");
            //return Console.ReadLine().ToString();
            return @"C:\Users\Andro\Desktop\Test Folder for VS project\";
        }
        static void DeleteMergedFile(string deletePath)
        {
            File.Delete(deletePath);
            
        }
        static string MergeFilesPath()
        {
            //Console.WriteLine("Give a valid path for merged file");
            //return Console.ReadLine().ToString();
            return @"C:\Users\Andro\Desktop\Test Folder for VS project\MergedFile.rtf";
        }
        static string[] FileNamesToArray(string folderPath, string fileTypeExtension)
        {
            string[] fileNamesArray = Directory.GetFiles(folderPath, "*" + fileTypeExtension);
            if (fileNamesArray.Length == 0)//if file type isn't present inform user
            {
                Console.WriteLine("That file type is not present in the folder you selected");
            }
            return fileNamesArray;
        }

      

    }
   

}
