﻿using Microsoft.Data.SqlClient;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public sealed partial class AdminView_AddService : Page
    {
        public AdminView_AddService()
        {
            this.InitializeComponent();
        }

        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            System.Text.StringBuilder result = new System.Text.StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                // Append a random uppercase letter to the result
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();        
        }

        private string GetNewID()
        {
            var connectionString = (App.Current as App).ConnectionString;
            var conn = new SqlConnection(connectionString);
            conn.Open();

            do
            {
                string s = GenerateRandomString(6);
                string query = $"select COUNT(*) from DICH_VU where MADV='{s}'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                int cnt = (int)cmd.ExecuteScalar();
                if (cnt <= 0)
                {
                    conn.Close();
                    return s;
                }
            }while(true);
            
        }

        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var title = Title.Text;
            var price = Price.Value;
            var id = GetNewID();

            string query = $"INSERT INTO DICH_VU VALUES('{id}',N'{title}', {price});";
            var connectionString = (App.Current as App).ConnectionString;
            var conn = new SqlConnection(connectionString);
            Debug.WriteLine(query);
            try
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    this.Frame.Navigate(typeof(AdminView_ServiceListPage));
                    ContentDialog addMedicineDialog = new ContentDialog
                    {
                        XamlRoot = this.XamlRoot,
                        Title = "Tạo mới dịch vụ",
                        Content = "Thêm dịch vụ mới thành công",
                        CloseButtonText = "OK"
                    };
                    ContentDialogResult result = await addMedicineDialog.ShowAsync();
                }
            } catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                ContentDialog FailDialog = new ContentDialog
                {
                    XamlRoot = this.XamlRoot,
                    Title = "Tạo mới dịch vụ",
                    Content = "Thêm dịch vụ thất bại",
                    CloseButtonText = "OK"
                };
                ContentDialogResult result = await FailDialog.ShowAsync();
            } finally {
                conn.Close();    
            }
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminView_ServiceListPage));
        }
    }
}