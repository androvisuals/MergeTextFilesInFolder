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
        //.txt is chosen as first string due to data only being passed when something changes
        String fileTypeChosen = String.Empty;// ".txt";

        //the selected folder path where the files are to merge together
        String selectedFolderPath = String.Empty;

        //the final Folder path where the merged file will be placed.
        String mergeFolderPath = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void SelectFolderClick(object sender, RoutedEventArgs e)
        {
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

        private void FileTypeComboBoxIntialize(object sender, EventArgs e)
        {
            // FileTypeComboBoxIntialize.
            // ... A List.
            List<string> data = new List<string>();
            data.Add(".txt");
            data.Add(".rtf");
            data.Add(".xml");
            

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            
            comboBox.ItemsSource= data;
            // ... Make the first item selected.
            comboBox.SelectedIndex = -1;
        }

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

                case ".rtf":
                    Console.WriteLine("User has selected " + fileTypeChosen);
                    break;

                case ".xml":
                    Console.WriteLine("User has selected " + fileTypeChosen);
                    break;

            }  
        }

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
                //tbxFolder.Text = selectedFolderPath;
                //</ Selected Path >
                Console.WriteLine("Select Folder Button has been clicked");
                Console.WriteLine("The folder path for the merged file is " + mergeFolderPath);
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
            //return @"C:\Users\Andro\Desktop\Test Folder for VS project\";
        }

        static void DeleteMergedFile(string deletePath)
        {
            File.Delete(deletePath);
            
        }

        static string MergeFileselectedFolderPath(string fileExtensionType)
        {
            Console.WriteLine("Give a valid path for merged file");
            string userInput = Console.ReadLine().ToString();
            //@ is to try and fix the .rtf formatting problem doesn't work yet
            return userInput + @"\" + fileExtensionType;
            //return @"C:\Users\Andro\Desktop\Test Folder for VS project\MergedFile.rtf";
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
