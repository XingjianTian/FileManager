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
using System.IO;
using System.Collections.ObjectModel;

namespace FilesManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public int FilesCount;
        CollectionViewSource view = new CollectionViewSource();
        //与List不同，observableCollections即时更新
        public ObservableCollection<MyFile> MyFiles = new ObservableCollection<MyFile>();
        //public List<MyFile> MyFiles = new List<MyFile>();
        int currentPageIndex = 0;
        int itemPerPage = 20;
        int totalPage = 0;

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            FilesCount = r.Next(22, 32);
            for (int i = 0; i < FilesCount; i++)
            {
                MyFiles.Add(new MyFile()
                {
                    MyFileID = i,
                    MyFileName = "File" + i.ToString(),
                    MyFileType = ".txt",
                    MyFileCreatedDate = Convert.ToString(System.DateTime.Now),
                    MyFilePath = "C:\\Users\\Public\\Documents\\",
                    MyFileData = "",
                });
                //write
                string path = MyFiles[i].MyFilePath + MyFiles[i].MyFileName + MyFiles[i].MyFileType;
                FileStream aFile = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                sw.WriteLine($"{MyFiles[i].MyFileID}\n");
                sw.WriteLine($"{MyFiles[i].MyFileData}\n");
                sw.WriteLine($"{MyFiles[i].MyFileCreatedDate}\n");
                sw.Close();
            }

            // Calculate the total pages
            totalPage = FilesCount / itemPerPage;
            if (FilesCount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = MyFiles;

            view.Filter += new FilterEventHandler(view_Filter);

            //显示列表数据
            this.listView1.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = MyFiles.IndexOf((MyFile)e.Item);

            if (index >= itemPerPage * currentPageIndex && index < itemPerPage * (currentPageIndex + 1))
                e.Accepted = true;
            else
                e.Accepted = false;
        }

        //Buttons
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            // Display the first page
            if (currentPageIndex != 0)
            {
                currentPageIndex = 0;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            // Display previous page
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Display next page
            if (currentPageIndex < totalPage - 1)
            {
                currentPageIndex++;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            // Display the last page
            if (currentPageIndex != totalPage - 1)
            {
                currentPageIndex = totalPage - 1;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnCreate_Click(object sender,RoutedEventArgs e)
        {
            Window1 CreateWindow = new Window1(MyFiles);
            CreateWindow.Title = "CreateFile";
            CreateWindow.Show();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            MyFile SelectedFile = listView1.SelectedItem/*选中项*/ as MyFile;
            MyFiles.Remove(SelectedFile);
            if (SelectedFile != null && SelectedFile is MyFile)
            {
                string path = SelectedFile.MyFilePath + SelectedFile.MyFileName + SelectedFile.MyFileType;
                File.Delete(path);
            }
        }
        private void btnReWrite_Click(object sender, RoutedEventArgs e)
        {
            int SelectedFilePos=0;
            MyFile SelectedFile = listView1.SelectedItem as MyFile;
            for(int i = 0;i< MyFiles.Count;i++)
            {
                if (MyFiles[i] == SelectedFile)
                    SelectedFilePos = i;

            }
            
            Window2 ReWriteWindow = new Window2(MyFiles,SelectedFilePos);
            ReWriteWindow.Title = "RewriteFile";
            ReWriteWindow.Show();
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            for(int i = 0;i<MyFiles.Count;i++)
            {
                string path = MyFiles[i].MyFilePath + MyFiles[i].MyFileName + MyFiles[i].MyFileType;
                File.Delete(path);
            }
        }

        private void btn_Search(object sender, RoutedEventArgs e)
        {
            Window4 SearchWindow = new Window4(MyFiles);
            SearchWindow.Title = "SearchFile";
            SearchWindow.Show();
        }
    }
}
