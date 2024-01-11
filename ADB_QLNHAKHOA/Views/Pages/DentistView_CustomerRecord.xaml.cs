using ADB_QLNHAKHOA.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DentistView_CustomerRecord : Page
    {
        public DentistView_CustomerRecord()
        {
            this.InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var list = CustomerVM1.getCustomersInfo(SearchTextBox.Text.ToString());
            danhsach.ItemsSource = list;
        }

        


        private void AddCus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMedicalRecordPage));
        }

        private void DeleteCus_Click(object sender, RoutedEventArgs e)
        {

        }


        private void lvItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(DentistView_CustomerInfo));
        }
    }
}
