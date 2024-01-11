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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DentistView_CustomerInfo : Page
    {


        public DentistView_CustomerInfo()
        {
            this.InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Dentist_MedicalRecordViewModels> list = new List<Dentist_MedicalRecordViewModels>();
            list = GetMedicalRecordViewModels((App.Current as App).ConnectionString, SearchTextBox.Text);
            danhsach.ItemsSource = list;
        }

        private List<Dentist_MedicalRecordViewModels> GetMedicalRecordViewModels(string connectionString, string ID)
        {
            List<Dentist_MedicalRecordViewModels> list = new List<Dentist_MedicalRecordViewModels>();
            String getPatientNameQuery;

            if (ID != "")
                getPatientNameQuery = $"SELECT BA.MABA, BA.MAKH, KH.HOTEN  FROM BENH_AN BA JOIN KHACH_HANG KH ON BA.MAKH = KH.MAKH WHERE BA.MABA = '{ID}'";
            else
                getPatientNameQuery = $"SELECT BA.MABA, BA.MAKH, KH.HOTEN FROM BENH_AN BA JOIN KHACH_HANG KH ON BA.MAKH = KH.MAKH";


            string _mrID;
            string _cusID;

            string _cusName;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(getPatientNameQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _mrID = reader.GetString(0);
                                _cusID = reader.GetString(1);
                                _cusName = reader.GetString(2);

                                list.Add(new Dentist_MedicalRecordViewModels(_mrID, _cusID, _cusName));
                            }
                        }
                    }
                }
                return list;

            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }
            return null;
        }

        private void lvItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Dentist_MedicalRecordViewModels;

            if (item != null)
            {
                this.Frame.Navigate(typeof(Dentist_MedicalRecordViewModels), item);
            }

        }

        private void AddCus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMedicalRecordPage));
        }

        private void DeleteCus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý khi nút xem Thông Tin được nhấp vào ở đây
            this.Frame.Navigate(typeof(DentistView_InfoCus));
        }

    }


}
