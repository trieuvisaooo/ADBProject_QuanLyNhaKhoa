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
            this.DataContext = viewModel;

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
            modifyInfo(sender, e);
            string phone = PhoneNum.Text;
            string birthday=DateOfBirth.Text;
            string email = Email.Text;
            string password = Password.Password;
            Debug.WriteLine($"{phone} {birthday} {email} {password}");
            this.Frame.Navigate(typeof(AdminView_AdminInfo), viewModel);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Modify.Visibility= Visibility.Visible;
            DateRow.Spacing = 30;
            DateOfBirth.Visibility = Visibility.Visible;
            ModifyDateOfBirth.Visibility = Visibility.Collapsed;
            PhoneNum.IsReadOnly = true;
            Email.IsReadOnly = true;
            Password.IsEnabled = false;
            SaveAndCancel.Visibility= Visibility.Collapsed;
        }

        private void ModifyInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            Modify.Visibility = Visibility.Collapsed;
            DateOfBirth.Visibility = Visibility.Collapsed;
            ModifyDateOfBirth.Visibility = Visibility.Visible;
            DateTime datetime = viewModel.Birthday.ToDateTime(TimeOnly.MinValue);
            ModifyDateOfBirth.Date = datetime;
            DateRow.Spacing = 15;
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
            Debug.WriteLine($"{phone} {birthday} {email} {password}");
            try
            {
                Debug.WriteLine("modified"+ModifyDateOfBirth.Date);
                bool result = viewModel.updateInfo(viewModel, phone, ModifyDateOfBirth.Date, email, password);
                if (result)
                {
                    ContentDialog modifiedDialog = new ContentDialog{
                        XamlRoot = this.XamlRoot,
                        Title = "Chỉnh sửa thông tin",
                        Content = "Bạn đã chỉnh sửa thông tin thành công",
                        CloseButtonText = "OK",
                    
                    };
                    ContentDialogResult showResult = await modifiedDialog.ShowAsync();
                }
                else
                {
                    ContentDialog FailDialog = new ContentDialog
                    {
                        XamlRoot = this.XamlRoot,
                        Title = "Chỉnh Sửa Thông Tin",
                        Content = "Chỉnh sửa thất bại!",
                        CloseButtonText = "Ok"
                    };

                ContentDialogResult showResult = await FailDialog.ShowAsync();    
                }
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
            }
        }

    }
}
