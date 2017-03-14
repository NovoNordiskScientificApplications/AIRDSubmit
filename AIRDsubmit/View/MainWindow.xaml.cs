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
        }

        ExcelViewModel viewModel;
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                try
                {
                    viewModel = new ExcelViewModel(openFileDialog.FileName);
                    viewModel.Load();
                    DataContext = viewModel;
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
                viewModel.Upload(Username.Text, Password.Password);
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
