using ADB_QLNHAKHOA.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DentistView_DenMakeAppointment : Page
    {
        private DentistInfoVM dentist = new DentistInfoVM();

        public DentistView_DenMakeAppointment()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dentist = e.Parameter as DentistInfoVM;
            dentist.getInfo(dentist);
        }


        public List<int> CusIDList = new List<int>();

        public List<int> getCustomers(string connectionString, string name)
        {
            string getCusListQuery = "select MABN from BENH_NHAN where HOTEN like N'" + name + "'";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = getCusListQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    CusIDList.Add(reader.GetInt32(0));
                                }
                            }
                        }
                    }
                }
                return CusIDList;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }
            return null;
        }

        private void Search_click(object sender, RoutedEventArgs e)
        {
            try
            {
                CusIDList.Clear();
                CusList.ItemsSource = getCustomers((App.Current as App).ConnectionString, search_box.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }


        private async void makeAppointment_Click(object sender, RoutedEventArgs e)
        {
            //string connectionString = (App.Current as App).ConnectionString;
            //SqlConnection con = new SqlConnection(@connectionString);
            //Debug.WriteLine(@connectionString);
            //string denName = (string)DenList.SelectedValue;
            //try
            //{
            //    con.Open();

            //    string insert_statement = "EXEC sp_themLHCoTenNS '" + customer.CusID + "', '" + AppoDate.Date + "', '" + AppoTime.Time + "', N'" + denName + "'";
            //    SqlCommand cmnd = new SqlCommand(insert_statement, con);
            //    cmnd.ExecuteNonQuery();
            //    this.Frame.Navigate(typeof(CustomerAppointment));
            //    ContentDialog MadeAppointmentDialog = new ContentDialog
            //    {
            //        XamlRoot = this.XamlRoot,
            //        Title = "Đăng Kí Lịch Hẹn",
            //        Content = "Bạn đã đăng kí lịch hẹn thành công!",
            //        CloseButtonText = "Ok"
            //    };
            //    ContentDialogResult result = await MadeAppointmentDialog.ShowAsync();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"Exception: {ex.Message}");
            //    ContentDialog FailDialog = new ContentDialog
            //    {
            //        XamlRoot = this.XamlRoot,
            //        Title = "Đăng Kí Lịch Hẹn",
            //        Content = "Đăng kí thất bại!",
            //        CloseButtonText = "Ok"
            //    };

            //    ContentDialogResult result = await FailDialog.ShowAsync();

            //}
            //finally
            //{
            //    con.Close();
            //}


        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DentistView_Appointment) ,dentist);
        }

    }
}
