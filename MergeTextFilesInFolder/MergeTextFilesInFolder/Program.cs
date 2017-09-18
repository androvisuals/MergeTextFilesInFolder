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

            Console.WriteLine("Pick a file type: 1 = txt 2= xml");
            int fileType = Convert.ToInt32 ( Console.ReadLine());

            string fileExtension = ".txt";
            if (fileType == 2)
            {
                fileExtension = ".xml";
            }
            //test path here, to paste right click top of console and select/edit/paste
            // C:\Users\Andro\Desktop\Test Folder for VS project
            string[] fileNamesArray = Directory.GetFiles(folderPath, "*"+fileExtension) ;
            if(fileNamesArray == null)
            {
                fileNamesArray[0] = "That is not  valid file path";
            }
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
