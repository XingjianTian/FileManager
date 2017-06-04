using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace FilesManager
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public ObservableCollection<MyFile> MyFiles;
        public Window4(ObservableCollection<MyFile> Files)
        {
            InitializeComponent();
            MyFiles = Files;
        }
        public Window4()
        {
            InitializeComponent();
        }

        private void btnSearchDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            bool IfThereIsSuchFile = false;
            MyFile searchfile = new MyFile
            {
                MyFileName = textBox1.Text,
                MyFileType = textBox2.Text,
                MyFileData = textBox4.Text,
                MyFilePath = textBox3.Text,
            };
            foreach (var eachfile in MyFiles)
            {
                if (searchfile.Matches(eachfile))
                {
                    IfThereIsSuchFile = true;
                    int SelectedFilePos = 0;
                    for (int i = 0; i < MyFiles.Count; i++)
                    {
                        if (MyFiles[i] == eachfile)
                            SelectedFilePos = i;
                    }
                    Window2 ReWriteWindow = new Window2(MyFiles, SelectedFilePos);
                    ReWriteWindow.Title = "Search Result";
                    ReWriteWindow.Show();
                }
            }
            if (!IfThereIsSuchFile)
            {
                
                Window3 WarningWindow = new Window3(MyFiles,searchfile);
                WarningWindow.Title = "No Such File";
                WarningWindow.Show();
            }
        }
    }
}
