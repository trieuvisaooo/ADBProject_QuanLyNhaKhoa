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
using System.Configuration;
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
        SqlConnection connection;

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
            
            var connectionString = ConfigurationManager.ConnectionStrings["QLNhaKhoaDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "";
            switch (selectedItemText)
            {
                case "Admin":
                    query = "SELECT * FROM [dbo].[QTV] WHERE MAQTV = @EMAIL AND MATKHAU = @MATKHAU";
                    break;
                case "Nhân viên":
                    query = "SELECT * FROM [dbo].[NHAN_VIEN] WHERE MANV = @EMAIL AND MATKHAU = @MATKHAU";
                    break;
                case "Nha sĩ":
                    query = "SELECT * FROM [dbo].[NHA_SI] WHERE MANS = @EMAIL AND MATKHAU = @MATKHAU";
                    break;
                default:
                    break;
            }

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
            command.Parameters.AddWithValue("@MATKHAU", txtPassword.Text);

            var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                switch (selectedItemText)
                {
                    case "Admin":
                        int id = (int)reader["MAQTV"];
                        
                        Window screen  = new AdminWindow(id);
                        this.Close();
                        screen.Activate();
                        break;
                    case "Nhân viên":
                        screen  = new StaffWindow();
                        this.Close();
                        screen.Activate();
                    
                        break;
                    case "Nha sĩ":
                        screen = new DentistWindow();
                        this.Close();
                        screen.Activate();
               
                        break;
                    default:
                        break;
                }
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
