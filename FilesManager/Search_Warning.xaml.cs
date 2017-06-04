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
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public ObservableCollection<MyFile> MyFiles;
        public MyFile searchfile;
        public Window3(ObservableCollection<MyFile> Files,MyFile TheFile)
        {
            InitializeComponent();
            MyFiles = Files;
            searchfile = TheFile;
        }
        public Window3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window1 CreateWindow = new Window1(MyFiles);
            CreateWindow.Title = "CreateFile";
            CreateWindow.Show();
            if(searchfile.MyFileName!="")
                CreateWindow.textBox1.Text = searchfile.MyFileName;
            if (searchfile.MyFileType != "")
                CreateWindow.textBox2.Text = searchfile.MyFileType;
            if (searchfile.MyFileData != "")
                CreateWindow.textBox4.Text = searchfile.MyFileData;
            if (searchfile.MyFilePath != "")
                CreateWindow.textBox3.Text = searchfile.MyFilePath;

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
