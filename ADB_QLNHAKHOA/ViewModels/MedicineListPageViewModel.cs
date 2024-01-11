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
    public class MedicineListPageViewModel: BaseViewModel
    {
        private string _id;
        private string _title;
        private int _price;
        private int _quantity;
        private DateOnly _expirationDate;
        private string _description;

        public string Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public int Price { get { return _price; } set { _price = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public DateOnly ExpirationDate { get { return _expirationDate;} set { _expirationDate = value; } }
        public string Description { get { return _description;} set { _description = value; } }

        public ObservableCollection<MedicineListPageViewModel> getAll(MedicineListPageViewModel viewModel)
        {
            try
            {
                string query = $"select MATHUOC, TENTHUOC, GIA, SLTON, HSD, CHONGCHIDINH from THUOC";
                var connectionString = ConfigurationManager.ConnectionStrings["QLNhaKhoaDbConnection"].ConnectionString;
                var conn = new SqlConnection(connectionString);
                conn.Open();
                var medicines = new ObservableCollection<MedicineListPageViewModel>();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {   
                        MedicineListPageViewModel vm = new MedicineListPageViewModel();
                        vm.Id = reader.GetString(0);
                        vm.Title = reader.GetString(1);
                        vm.Price = reader.GetInt32(2);
                        vm.Quantity = reader.GetInt32(3);
                        DateTime date = reader.GetDateTime(4);
                        vm.ExpirationDate = DateOnly.FromDateTime(date);
                        vm.Description = reader.GetString(5);
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
