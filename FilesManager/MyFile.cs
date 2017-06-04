using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager
{
    public class MyFile:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public int MyFileID { get; set; }
        private int _MyFileID;
        public int MyFileID
        {
            get { return _MyFileID; }
            set
            {
                _MyFileID = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyFileID"));
                }
            }
        }
        private string _MyFileName;
        public string MyFileName
        {
            get { return _MyFileName; }
            set
            {
                _MyFileName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyFileName"));
                }
            }
        }
        private string _MyFileType;
        public string MyFileType
        {
            get { return _MyFileType; }
            set
            {
                _MyFileType = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyFileType"));
                }
            }
        }
        //public string MyFileName { get; set; }
        //public string MyFileType { get; set; }
        //public string MyFileCreatedDate { get; set; }

        private string _MyFileCreatedDate;
        public string MyFileCreatedDate
        {
            get { return _MyFileCreatedDate; }
            set
            {
                _MyFileCreatedDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyFileCreatedDate"));
                }
            }
        }
        //public string MyFilePath { get; set; }
        private string _MyFilePath;
        public string MyFilePath
        {
            get { return _MyFilePath; }
            set
            {
                _MyFilePath = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyFilePath"));
                }
            }
        }
        //public string MyFileData { get; set; }
        private string _MyFileData;
        public string MyFileData
        {
            get { return _MyFileData; }
            set
            {
                _MyFileData = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyFileData"));
                }
            }
        }

        public bool Matches(MyFile AnotherFile)
        {
            bool IfMatch = true;
            
            if ((MyFileName != "" && MyFileName != AnotherFile.MyFileName)||
                (MyFileData != "" && MyFileData != AnotherFile.MyFileData)||
                (MyFilePath != "" && MyFilePath != AnotherFile.MyFilePath)||
                (MyFileType != "" && MyFileType != AnotherFile.MyFileType)
                )
                IfMatch = false;
            return IfMatch;
        }

    }
}
