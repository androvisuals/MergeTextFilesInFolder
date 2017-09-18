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
            Console.WriteLine("Give a valid path to the folder.");
            string folderPath =   Console.ReadLine().ToString();

            Console.WriteLine("Define your file type, example : .xml or .txt");
            string fileTypeExtension =  Console.ReadLine().ToString();

            
            //test path here, to paste right click top of console and select/edit/paste
            // C:\Users\Andro\Desktop\Test Folder for VS project
            string[] fileNamesArray = Directory.GetFiles(folderPath, "*"+ fileTypeExtension) ;
            if(fileNamesArray == null)
            {
                fileNamesArray[0] = "That is not  valid file path";
            }
            Console.WriteLine("You picked the file type " + fileTypeExtension);
            Console.WriteLine("All the files that match your folder and selection are:");
            //Display all files
            foreach (string name in fileNamesArray)
            {
                //writes each file name out for debugging purposes
                Console.WriteLine(name);
            }
            
            Console.ReadLine();
        }
    }
   

}
