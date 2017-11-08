using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AIRDsubmit
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
        
        public string _username = App.Settings["Username"];
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    App.Settings["Username"] = value;
                    _username = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ExcelViewModel _excelViewModel;
        public ExcelViewModel ExcelViewModel
        {
            get { return _excelViewModel; }
            set
            {
                if (_excelViewModel != value)
                {
                    _excelViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void LoadExcelSheet(string fileName) => ExcelViewModel = new ExcelViewModel(fileName);

        internal void Upload(string password) => ExcelViewModel.Upload(Username, password);
    }
}
