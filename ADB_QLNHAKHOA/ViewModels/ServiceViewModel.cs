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
    public class ServiceViewModel
    {
        private string _id;
        private string _title;
        private int _price;

        public string Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public int Price { get { return _price; } set { _price = value; } }

        public ObservableCollection<ServiceViewModel> getAll(ServiceViewModel viewModel)
        {
            try
            {
                string query = $"select MADV, TENDV, GIA from DICH_VU";
                var connectionString = (App.Current as App).ConnectionString;
                var conn = new SqlConnection(connectionString);
                conn.Open();
                var medicines = new ObservableCollection<ServiceViewModel>();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {   
                        ServiceViewModel vm = new ServiceViewModel();
                        vm.Id = reader.GetString(0);
                        vm.Title = reader.GetString(1);
                        vm.Price = reader.GetInt32(2);
                        
                        medicines.Add(vm);
                    }
                }
                return medicines;
            } catch (Exception ex) {
                Debug.WriteLine(ex);    
            }
            return null;
        }
    }
}
