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
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginWindow : Window
    {
        private string connectionString = @"Server=VANTRANY\SQLEXPRESS;DATABASE=QLNHAKHOA;Integrated Security=True;Encrypt=False";
        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public LoginWindow()
        {
            this.InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedItemText = (string)menuFlyout.Content;
            if (selectedItemText == "Vai trò")
            {
                MessageBox.Show("Hãy chọn vai trò");
                return;
            }
            SqlConnection con  = new SqlConnection(ConnectionString);
            con.Open();

            string queryTable = "";
            Window w1 = null;
            switch (selectedItemText)
            {
                case "Admin":
                    w1 = new AdminWindow();
                    queryTable = "QTV";
                    break;
                case "Nhân viên":
                    w1 = new StaffWindow();
                    queryTable = "NHAN_VIEN";
                    break;
                case "Nha sĩ":
                    w1 = new DentistWindow();
                    queryTable = "NHA_SI";
                    break;
                default:
                    break;
            }

            string query = "SELECT * FROM [dbo].[" + queryTable + "] WHERE EMAIL = @EMAIL AND MATKHAU = @MATKHAU";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
            command.Parameters.AddWithValue("@MATKHAU", txtPassword.Text);

            command.ExecuteNonQuery();
            
            int count = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            
            if (count > 0)
            {
                this.Close();
                w1.Activate();
            } else
            {
                MessageBox.Show("Sai mật khẩu");
            }

        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem menuItem)
            {
                string selectedItemText = menuItem.Text;
                Debug.WriteLine(selectedItemText);
                switch (selectedItemText)
                {
                    case "Admin":
                        menuFlyout.Content = selectedItemText;
                        break;
                    case "Nha sĩ":
                        menuFlyout.Content = selectedItemText;
                        break;
                    case "Nhân viên":
                        menuFlyout.Content = selectedItemText;
                        break;
                    // Add more cases for other MenuFlyoutItem texts if needed
                    default:
                        break;
                }
            }
        }
    }
}
