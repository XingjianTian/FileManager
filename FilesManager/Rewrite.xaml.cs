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
using Microsoft.VisualBasic.Devices;

namespace FilesManager
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        int Pos;
        public ObservableCollection<MyFile> MyFiles;
        string OriginPath;
        public Window2(ObservableCollection<MyFile> Files,int pos)
        {
            InitializeComponent();
            MyFiles = Files;
            Pos = pos;

            textBox1.Text = MyFiles[Pos].MyFileName;
            textBox2.Text = MyFiles[Pos].MyFileType;
            textBox4.Text = MyFiles[Pos].MyFileData;
            textBox3.Text = MyFiles[Pos].MyFilePath;

            

            OriginPath = MyFiles[Pos].MyFilePath + MyFiles[Pos].MyFileName + MyFiles[Pos].MyFileType;
        }

        public Window2()
        {
            InitializeComponent();
        }

        private void btnReWriteDone_Click(object sender,RoutedEventArgs e)
        {
            //FilesCount++;

            MyFiles[Pos].MyFileName = textBox1.Text;
            MyFiles[Pos].MyFileType = textBox2.Text;
            MyFiles[Pos].MyFileCreatedDate = Convert.ToString(System.DateTime.Now);
            MyFiles[Pos].MyFileData = textBox4.Text;
            MyFiles[Pos].MyFilePath = textBox3.Text;
             
            FileStream aFile = new FileStream(OriginPath, FileMode.OpenOrCreate);
            aFile.SetLength(0);
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine($"{MyFiles[Pos].MyFileID}\n");
            sw.WriteLine($"{MyFiles[Pos].MyFileData}\n");
            sw.WriteLine($"{MyFiles[Pos].MyFileCreatedDate}\n");
            sw.Close();

            string newname = MyFiles[Pos].MyFileName+ MyFiles[Pos].MyFileType;

            //调用vb的重命名
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.RenameFile(OriginPath, newname);

            Close();
        }

    }
}
