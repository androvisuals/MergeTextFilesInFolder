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
            Console.WriteLine("Define your file type to merge , example : .xml or .txt");
            string fileTypeExtension = Console.ReadLine().ToString();

            Console.WriteLine("Give a valid path to the folder.");
            string folderPath =   Console.ReadLine().ToString();

            

            string[] fileNamesArray = Directory.GetFiles(folderPath, "*" + fileTypeExtension);
            //test path here, to paste right click top of console and select/edit/paste
            // C:\Users\Andro\Desktop\Test Folder for VS project

            if(fileNamesArray.Length == 0 )
            {
                Console.WriteLine("That file type is not present in the folder you selected");
            }
            try
            {
                
                Console.WriteLine("You picked the file type " + fileTypeExtension);
                Console.WriteLine("All the files that match your folder and selection are:");
                //Display all files
                foreach (string name in fileNamesArray)
                {
                    //writes each file name out for debugging purposes
                    Console.WriteLine(Path.GetFileName( name));
                }
            }
            catch (System.IO.DirectoryNotFoundException e )
            {
                //throw e;
                Console.WriteLine("an error has occured: '{0}' ", e.Message);
            }

                
           

            
            
            Console.ReadLine();
        }
    }
   

}
