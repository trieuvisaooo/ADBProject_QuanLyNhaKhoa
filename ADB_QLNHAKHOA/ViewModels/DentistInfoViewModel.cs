using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.ViewModels
{
    public class DentistInfoViewModel: UserInfoViewModel
    {
        public DentistInfoViewModel() { }
        public ObservableCollection<DentistInfoViewModel> getStaffs()
        {
            try
            {
                string query = $"select MANS, HOTEN, NGSINH, SDT, EMAIL, MATKHAU from NHA_SI";
                var connectionString = (App.Current as App).ConnectionString;
                var conn = new SqlConnection(connectionString);
                conn.Open();
                var staffs = new ObservableCollection<DentistInfoViewModel>();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();
                    Debug.WriteLine(query);
                    while (reader.Read())
                    {   
                        DentistInfoViewModel vm = new DentistInfoViewModel();
                        vm.Id = reader.GetInt32(0);
                        vm.Name = reader.GetValue(1) != DBNull.Value ? reader.GetString(1) : "";
                        DateTime date = reader.GetValue(2) != DBNull.Value ? reader.GetDateTime(2) : new DateTime(1980, 1, 1);
                        vm.Birthday = DateOnly.FromDateTime(date);  
                        vm.Phone = reader.GetValue(3) != DBNull.Value ? reader.GetString(3) : null;
                        vm.Email = reader.GetValue(4) != DBNull.Value ? reader.GetString(4) : null;
                        vm.Password = reader.GetValue(5) != DBNull.Value ? reader.GetString(5) : null;
                        staffs.Add(vm);
                    }
                }
                return staffs;
            } catch (Exception ex) {
                Debug.WriteLine(ex);    
            }
            return null;
        }

        public DentistInfoViewModel getDetail(int id)
        {
            try
            {
                var staff = new DentistInfoViewModel();
                string query = $"select MANS, HOTEN, NGSINH, SDT, EMAIL, MATKHAU FROM NHA_SI where MANS = {id}";
                var connectionString = (App.Current as App).ConnectionString;
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
                                    staff.Id = reader.GetInt32(0);
                                    staff.Name = reader.GetString(1);
                                    DateTime date = reader.GetDateTime(2);
                                    staff.Birthday = DateOnly.FromDateTime(date);
                                    staff.Phone = reader.GetString(3);
                                    staff.Email = reader.GetString(4);
                                    staff.Password = reader.GetString(5);
                                }

                            }
                        }
                    }
                }
                return staff;
            } catch(Exception eSql)
            {
                Debug.WriteLine(eSql);  
            }
            return null;
        }

        public bool updateInfo(DentistInfoViewModel adminInfo, string phone, object birthday, string email, string password)
        {
            var connectionString = (App.Current as App).ConnectionString;
            var query = $"UPDATE NHA_SI SET SDT='{phone}', NGSINH='{birthday}', EMAIL='{email}', MATKHAU='{password}' WHERE MANS={adminInfo.Id}";
            Debug.WriteLine("query: ", query);
            var conn = new SqlConnection(connectionString);
            
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open) { 
                    using (SqlCommand cmd = conn.CreateCommand()) 
                    { 
                        cmd.CommandText = query; 
                        cmd.ExecuteNonQuery();
                    } 
                }
                return true;
            } catch(System.Exception e)
            {
                Debug.WriteLine(e);
                return false;
            } finally { conn.Close(); }

        }

        public ObservableCollection<DentistInfoViewModel> getStaffsByName(string str)
        {    
            try
            {
                Debug.WriteLine(str);
                string query = $"select MANS, HOTEN, NGSINH, SDT, EMAIL, MATKHAU from NHA_SI where HOTEN LIKE N'%{str}%'";
                var connectionString = (App.Current as App).ConnectionString;
                var conn = new SqlConnection(connectionString);
                conn.Open();
                var staffs = new ObservableCollection<DentistInfoViewModel>();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();
                    Debug.WriteLine(query);
                    while (reader.Read())
                    {   
                        DentistInfoViewModel vm = new DentistInfoViewModel();
                        vm.Id = reader.GetInt32(0);
                        vm.Name = reader.GetValue(1) != DBNull.Value ? reader.GetString(1) : "";
                        DateTime date = reader.GetValue(2) != DBNull.Value ? reader.GetDateTime(2) : new DateTime(1980, 1, 1);
                        vm.Birthday = DateOnly.FromDateTime(date);  
                        vm.Phone = reader.GetValue(3) != DBNull.Value ? reader.GetString(3) : null;
                        vm.Email = reader.GetValue(4) != DBNull.Value ? reader.GetString(4) : null;
                        vm.Password = reader.GetValue(5) != DBNull.Value ? reader.GetString(5) : null;
                        staffs.Add(vm);
                    }
                }
                return staffs;
            } catch (Exception ex) {
                Debug.WriteLine(ex);    
            }
            return null;
        }
    }
}
