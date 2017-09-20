using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForms = System.Windows.Forms;

namespace MergeTextFilesinFolderGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //The chosen file type to merge, based on file extension like  ".txt" ".rtf"
        String fileTypeChosen = String.Empty;// ".txt";

        //the selected folder path where the files are to merge together
        String selectedFolderPath = String.Empty;

        //the final Folder path where the merged file will be placed.
        String mergeFolderPath = String.Empty;

        //Placeholder for file name, if user leaves blank then it becomes something like MergedFile.txt
        String userDefinedFileName = "MergedFile";

        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        //When select folder button is clicked run the following code
        private void SelectFolderClick(object sender, RoutedEventArgs e)
        {
            //Used to allow the user to browse to a folder
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                //----< Selected Folder >---- 
                //< Selected Path > 
                selectedFolderPath = folderDialog.SelectedPath;
                //tbxFolder.Text = selectedFolderPath;
                //</ Selected Path >
                Console.WriteLine("Select Folder Button has been clicked");
                Console.WriteLine("The folder path you selected is " + selectedFolderPath);
            }
        }

        //Fills ComboBox with all file types.
        private void FileTypeComboBoxIntialize(object sender, EventArgs e)
        {
            // FileTypeComboBoxIntialize.
            // ... A List.
            List<string> data = new List<string>();
            data.Add(".txt");
            //data.Add(".rtf");
            data.Add(".xml");
            

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            
            comboBox.ItemsSource= data;
            // ... Make the first item selected.
            comboBox.SelectedIndex = -1;
        }

        //If user picks something in the comboBox run this code. Changes string "filetypeChosen"
        private void FileTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;
            // ... Set fileTypeChosen string to what the user has picked
            fileTypeChosen = comboBox.SelectedItem as string;

            //basic switch system based upon file extension.
            switch (fileTypeChosen)
            {
                case ".txt":
                    Console.WriteLine("User has selected " + fileTypeChosen);
                    break;
                /*
                case ".rtf":
                    Console.WriteLine("User has selected " + fileTypeChosen);
                    break;
                */
                case ".xml":
                    Console.WriteLine("User has selected " + fileTypeChosen);
                    break;

            }  
        }

        //Run when user clicks the button for the merged file location. Changes string "mergeFolderPath"
        private void SelectMergeLocationButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                //----< Selected Folder >---- 
                //< Selected Path > 
                mergeFolderPath = folderDialog.SelectedPath;
             
                Console.WriteLine("Select Folder Button has been clicked");
                Console.WriteLine("The folder path for the merged file is " + mergeFolderPath);
            }
        }
        //This runs all the main code when the user presses the merge button
        private void MergeButtonClick(object sender, RoutedEventArgs e)
        {
            //This is where all the final processing takes place

            //merges all strings together for the final merged file 
            mergeFolderPath = mergeFolderPath +@"\"+userDefinedFileName+fileTypeChosen;
          
            //deletes any previous merged file to avoid exceptions being thrown
            DeleteMergedFile(mergeFolderPath);

            //create an array of strings made up of all matching files. example fileNamesArray[0] = "TextFile_01.txt"
            string[] fileNamesArray = FileNamesToArray(selectedFolderPath, fileTypeChosen);

            //used to catch exceptions, still need to add more. Placeholder
            try
            {
                //Empty string to avoid null.
                string finalResult = String.Empty;
                
                //iterates as many times as there are files inthe folder that match file type extension.
                foreach (string name in fileNamesArray)
                {
                    //StreamReader Class used to read files
                    using (StreamReader reader = new StreamReader(name))
                    {
                        //reads entire file from start to end, causes problems with rtf
                        string line = reader.ReadToEnd();

                        //may be used later if i need to use StreamReader on a per line basis
                        finalResult = line;

                        //StreamWriter adds data to the stream until foreach is finished iterating
                        using (StreamWriter writer = File.AppendText(mergeFolderPath))
                        {
                            //write data to file on each iteration
                            writer.Write(finalResult);
                        }
                    }
                }
            }
            //To catch exceptions, still have to figure out how to add mutliple catch expressions.
            catch (System.IO.DirectoryNotFoundException error)
            {
                //throws error when a directory cannot be found, still needs
                //to be routed to an actual debug window in the gui
                Console.WriteLine("an error has occured: '{0}' ", error.Message);
            }
            
        }


        /* ALL FUNCTIONS */

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
            Console.WriteLine("Give a valid path to the folder.");
            return Console.ReadLine().ToString();
        }

        //Used to delete any previous merged file. If we don't delete it all gets appended to an existing file.
        static void DeleteMergedFile(string deletePath)
        {
            File.Delete(deletePath);   
        }

        // Gets all file names from a folder that match the file extension that was chosen.
        //Array.Length = totalMatchingFiles
        static string[] FileNamesToArray(string folderPath, string fileTypeExtension)
        {
            //fill each array index with each matching file type
            string[] fileNamesArray = Directory.GetFiles(folderPath, "*" + fileTypeExtension);
            //if Array.length == 0 then no matching file was found, PUSH to DEBUG GUI
            if (fileNamesArray.Length == 0)
            {
                Console.WriteLine("That file type is not present in the folder you selected");
            }
            return fileNamesArray;
        }

        //if user types a file name into the text box then this updates the userDefinedFileName string
        private void UserDefinedNameTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            userDefinedFileName = UserDefinedFileName.Text;
            Console.WriteLine("User defined file name is " + userDefinedFileName);
        }
    }
}
