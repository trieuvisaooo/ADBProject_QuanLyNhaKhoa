using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.ViewModels
{
    public class AdminInfoViewModel: UserInfoViewModel
    {
        
        public AdminInfoViewModel() { }
        public AdminInfoViewModel(int id) { 
            Id = id;
        }
        public AdminInfoViewModel getInfo(AdminInfoViewModel adminInfo)
        {
            try
            {
                string query = "select MAQTV, HOTEN, NGSINH, SDT, EMAIL, MATKHAU FROM QTV where MAQTV = " + adminInfo.Id.ToString();
                var connectionString = ConfigurationManager.ConnectionStrings["QLNhaKhoaDbConnection"].ConnectionString;
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = query;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    adminInfo.Id = reader.GetInt32(0);
                                    adminInfo.Name = reader.GetString(1);
                                    DateTime date = reader.GetDateTime(2);
                                    adminInfo.Birthday = DateOnly.FromDateTime(date);
                                    adminInfo.Phone = reader.GetString(3);
                                    adminInfo.Email = reader.GetString(4);
                                    adminInfo.Password = reader.GetString(5);
                                }

                            }
                        }
                    }
                }
                return adminInfo;
            } catch(Exception eSql) { 
                Debug.WriteLine(eSql);    
            }
            return null;
        }
    }
}
