using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AIRDsubmit
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel = new MainViewModel();
        }

        MainViewModel viewModel;
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Excel Workbooks (*.xlsx)|*.xlsx",
                RestoreDirectory = true,
                CheckFileExists = true,
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    viewModel.LoadExcelSheet(openFileDialog.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.Upload(Password.Password);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var r = e.Row.Item as RecordViewModel;
            if(r != null && r.Uploaded == true)
                e.Cancel = true;
        }
    }
}
