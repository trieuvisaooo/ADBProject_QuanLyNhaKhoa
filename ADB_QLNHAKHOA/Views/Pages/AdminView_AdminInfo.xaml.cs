using ADB_QLNHAKHOA.ViewModels;
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
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Data.SqlClient;
using System.Configuration;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminView_AdminInfo : Page
    {
        private AdminInfoViewModel viewModel = new AdminInfoViewModel();
        private int _id;

        public AdminView_AdminInfo()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            viewModel = e.Parameter as AdminInfoViewModel;
            viewModel.getInfo(viewModel);
            Password.Password = viewModel.Password;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifyInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            Modify.Visibility = Visibility.Collapsed;
            DateOfBirth.Visibility = Visibility.Collapsed;
            ModifyDateOfBirth.Visibility = Visibility.Visible;
            DateTime datetime = viewModel.Birthday.ToDateTime(TimeOnly.MinValue);
            ModifyDateOfBirth.Date = datetime;
            DateRow.Spacing = 20;
            PhoneNum.IsReadOnly = false;
            Email.IsReadOnly = false;
            Password.IsEnabled = true;
            SaveAndCancel.Visibility = Visibility.Visible;
        }

        private async void modifyInfo(object sender, RoutedEventArgs e)
        {
            string phone = PhoneNum.Text;
            string birthday=DateOfBirth.Text;
            string email = Email.Text;
            string password = Password.Password;
            string connectionString = ConfigurationManager.ConnectionStrings["QLNhaKhoaDbConnection"].ConnectionString;
            try
            {

            } catch(Exception ex) {
                Debug.WriteLine($"Exception: {ex.Message}");
                ContentDialog FailDialog = new ContentDialog
                {
                    XamlRoot = this.XamlRoot,
                    Title = "Chỉnh Sửa Thông Tin",
                    Content = "Chỉnh sửa thất bại!",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await FailDialog.ShowAsync();    
            } finally
            {

            }
        }
    }
}
