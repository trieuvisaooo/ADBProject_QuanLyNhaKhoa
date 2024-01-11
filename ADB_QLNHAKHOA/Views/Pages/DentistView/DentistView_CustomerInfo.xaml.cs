using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ADB_QLNHAKHOA.Models;
using ADB_QLNHAKHOA.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DentistView_CustomerInfo : Page
    {
        private DentistView_CustomerRecordVM customerInfo;

        public DentistView_CustomerInfo()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            customerInfo = e.Parameter as DentistView_CustomerRecordVM;
            //medicine_list.ItemsSource = CRViewModel.GetMedicine((App.Current as App).ConnectionString);
            //service_list.ItemsSource = CRViewModel.GetService((App.Current as App).ConnectionString);
        }

        private async void modifyInfo(object sender, RoutedEventArgs e, string connectionString)
        {
            SqlConnection con = new SqlConnection(@connectionString);
            try
            {
                con.Open();

                string update_statement = "UPDATE BENH_NHAN SET SDT = '" + PhoneNum.Text + "', TT_RANGMIENG = N'" + TTRangMieng.Text + "', NGSINH = '" + ModifyDateOfBirth.Date + "', CHONGCHIDINH = '" + ChongChiDinh.Text
                    + "', GHICHUDIUNG = '" + GhiChuDiUng.Text + "' WHERE MABN = '" + customerInfo.Id + "'";
                Debug.WriteLine(update_statement);
                SqlCommand cmnd = new SqlCommand(update_statement, con);
                cmnd.ExecuteNonQuery();
                ContentDialog ModifiedDialog = new ContentDialog
                {
                    XamlRoot = this.XamlRoot,
                    Title = "Chỉnh Sửa Thông Tin",
                    Content = "Bạn đã chỉnh sửa thông tin thành công thành công!",
                    CloseButtonText = "Ok"
                };
                ContentDialogResult result = await ModifiedDialog.ShowAsync();
            }
            catch (Exception ex)
            {
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
            finally
            {
                con.Close();
            }
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            Modify.Visibility = Visibility.Collapsed;
            DateOfBirth.Visibility = Visibility.Collapsed;
            ModifyDateOfBirth.Visibility = Visibility.Visible;
            DateTime dateTime = customerInfo.Birthday.ToDateTime(TimeOnly.MinValue);
            ModifyDateOfBirth.Date = dateTime;
            DateRow.Spacing = 15;
            PhoneNum.IsReadOnly = false;
            TTRangMieng.IsReadOnly = false;
            ChongChiDinh.IsReadOnly = false;
            GhiChuDiUng.IsReadOnly = false;
            SaveAndCancel.Visibility = Visibility.Visible;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            modifyInfo(sender, e, (App.Current as App).ConnectionString);
            this.Frame.Navigate(typeof(DentistView_CustomerInfo), customerInfo);

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Modify.Visibility = Visibility.Visible;
            DateRow.Spacing = 30;
            DateOfBirth.Visibility = Visibility.Visible;
            ModifyDateOfBirth.Visibility = Visibility.Collapsed;
            PhoneNum.IsReadOnly = true;
            TTRangMieng.IsReadOnly = true;
            ChongChiDinh.IsEnabled = true;
            GhiChuDiUng.IsEnabled = true;
            SaveAndCancel.Visibility = Visibility.Collapsed;
        }
    }
}
