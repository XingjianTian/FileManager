using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        //public List<MyFile> MyFiles;
        public ObservableCollection<MyFile> MyFiles;
        public Window1(ObservableCollection<MyFile> Files)
        {
            InitializeComponent();
            MyFiles = Files;
        }

        public Window1()
        {
            InitializeComponent();
        }

        private void btnCreateDone_Click(object sender,RoutedEventArgs e)
        {
            int last = MyFiles.Count;
            MyFiles.Add(new MyFile()
            {
                MyFileID = MyFiles[last-1].MyFileID+1,
                MyFileName = textBox1.Text,
                MyFileType = textBox2.Text,
                MyFileCreatedDate = Convert.ToString(System.DateTime.Now),
                MyFileData = textBox4.Text,
                MyFilePath = textBox3.Text,
            });
            string path = MyFiles[last].MyFilePath + 
                MyFiles[last].MyFileName + 
                MyFiles[last].MyFileType;
            FileStream aFile = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine($"{MyFiles[last].MyFileID}\n");
            sw.WriteLine($"{MyFiles[last].MyFileData}\n");
            sw.WriteLine($"{MyFiles[last].MyFileCreatedDate}\n");
            sw.Close();
            Close();
        }

    }
}
