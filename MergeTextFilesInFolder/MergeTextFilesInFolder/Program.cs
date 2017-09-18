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

            //test path here
            // C:\Users\Andro\Desktop\Test Folder for VS project
            string[] fileNamesArray = Directory.GetFiles(folderPath) ;

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
