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
    public class DentistInfoVM : UserInfoViewModel
    {
        private int _clinicID;
        private string _specialize;
        public int ClinicID
        {
            get
            {
                return _clinicID;
            }
            set
            {
                _clinicID = value;
                OnPropertyChanged(nameof(_clinicID));
            }
        }

        public string Specialize
        {
            get
            {
                return _specialize;
            }
            set
            {
                _specialize = value;
                OnPropertyChanged(nameof(_specialize));
            }
        }

        public DentistInfoVM() { }
        public DentistInfoVM(int id)
        {
            Id = id;
        }
        public DentistInfoVM getInfo(DentistInfoVM dentistInfo)
        {
            try
            {
                string query = "select MANS, HOTEN, NGSINH, SDT, EMAIL, MATKHAU, MAPHONGKHAM, CHUYENMON FROM NHA_SI where MANS = " + dentistInfo.Id.ToString();
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
                                    dentistInfo.Id = reader.GetInt32(0);
                                    dentistInfo.Name = reader.GetString(1);
                                    DateTime date = reader.GetDateTime(2);
                                    dentistInfo.Birthday = DateOnly.FromDateTime(date);
                                    dentistInfo.Phone = reader.GetString(3);
                                    dentistInfo.Email = reader.GetString(4);
                                    dentistInfo.Password = reader.GetString(5);
                                    dentistInfo.ClinicID = reader.GetInt32(6);
                                    dentistInfo.Specialize = reader.GetString(7);
                                }

                            }
                        }
                    }
                }
                return dentistInfo;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine(eSql);
            }
            return null;
        }

        public bool updateInfo(DentistInfoVM dentistInfo, string phone, object birthday, string email, string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["QLNhaKhoaDbConnection"].ConnectionString;
            var query = $"UPDATE NHA_SI SET SDT='{phone}', NGSINH='{birthday}', EMAIL='{email}', MATKHAU='{password}' WHERE MANS={dentistInfo.Id}";
            Debug.WriteLine("query: ", query);
            var conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            finally { conn.Close(); }

        }
    }
}
