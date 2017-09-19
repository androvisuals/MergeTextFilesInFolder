using System;
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
        //the selected folder path where the files are to merge
        String sPath = String.Empty;
        //The chosen file type to merge, based on file extension like  ".txt" ".rtf"
        //.txt is chosen as first string due to data only being passed when something changes
        String fileTypeChosen = String.Empty;// ".txt";
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
                sPath = folderDialog.SelectedPath;
                //tbxFolder.Text = sPath;
                //</ Selected Path >
                Console.WriteLine("Select Folder Button has been clicked");
                Console.WriteLine("The folder path you selected is " + sPath);
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
            // ... Set SelectedItem as Window Title.
            fileTypeChosen = comboBox.SelectedItem as string;
            //this.Title = "Selected: " + value;
            //Console.WriteLine("User has selected the file type " + fileTypeChosen);

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
    }
}
