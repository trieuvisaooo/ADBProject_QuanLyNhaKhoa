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
    public class CustomerVM1 : UserInfoViewModel
    {
        private string _gender;
        private string _tinhTrang;
        private string _chongCD;
        private string _noteDiUng;

        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(_gender));
            }
        }

        public string TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
                _tinhTrang = value;
                OnPropertyChanged(nameof(_tinhTrang));
            }
        }

        public string ChongCD
        {
            get
            {
                return _chongCD;
            }
            set
            {
                _chongCD = value;
                OnPropertyChanged(nameof(_chongCD));
            }
        }

        public string NoteDiUng
        {
            get { return _noteDiUng; }
            set { _noteDiUng = value;
            OnPropertyChanged(nameof(_noteDiUng));
            }
        }

        public CustomerVM1() { }
        public CustomerVM1(int id)
        {
            Id = id;
        }
        public CustomerVM1 getInfo(CustomerVM1 customerInfo)
        {
            try
            {
                string query = "select HOTEN,NGSINH,GIOITINH,SDT,EMAIL,TT_RANGMIENG ,CHONGCHIDINH,GHICHUDIUNG FROM BENH_NHAN where MABN = " + customerInfo.Id.ToString();
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
                                    customerInfo.Id = reader.GetInt32(0);
                                    customerInfo.Name = reader.GetString(1);
                                    DateTime date = reader.GetDateTime(2);
                                    customerInfo.Birthday = DateOnly.FromDateTime(date);
                                    customerInfo.Gender = reader.GetString(3);
                                    customerInfo.Phone = reader.GetString(4);
                                    customerInfo.Email = reader.GetString(5);
                                    customerInfo.TinhTrang= reader.GetString(6);
                                    customerInfo.ChongCD = reader.GetString(7);
                                    customerInfo.NoteDiUng = reader.GetString(8);
                                    
                                }

                            }
                        }
                    }
                }
                return customerInfo;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine(eSql);
            }
            return null;
        }

        public static List<CustomerVM1> getCustomersInfo(string ID)
        {
            var list = new List<CustomerVM1>(); 
            try
            {
                string query = "";

                if(ID != "")
                {
                   query = $"select * FROM BENH_NHAN WHERE MABN = {ID}";
                }
                else {
                    query = $"select * FROM BENH_NHAN";
                }

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
                                    CustomerVM1 customer = new CustomerVM1();
                                    customer.Id = (int)reader["ID"];
                                    customer.Name = (string)reader["HOTEN"];
                                    customer.Birthday = (DateOnly)reader["NGSINH"];
                                    customer.Gender = (string)reader["GIOITINH"];
                                    customer.Phone = (string)reader["SDT"];
                                    customer.Email = (string)reader["EMAIL"];
                                    customer.TinhTrang = (string)reader["TT_RANGMIENG"];
                                    customer.ChongCD = (string)reader["CHONGCHIDINH"];
                                    customer.NoteDiUng = (string)reader["GHICHUDIUNG"];

                                    list.Add(customer);

                                }

                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine(eSql);
            }
            return null;
        }

    }
}
