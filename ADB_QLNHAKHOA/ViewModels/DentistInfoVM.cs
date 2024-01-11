using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.ViewModels
{
    public class DentistInfoVM : INotifyPropertyChanged
    {
        private int _denID;
        private string _denName;
        private DateOnly _dateOfBirth;
        private string _phoneNum;
        private string _email;
        private int _addr;
        private string _spec;

        public int _DenID
        {
            get; set;
        }
        public string _DenName
        {
            get; set;
        }

        public DateOnly DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                NotifyPropertyChanged(nameof(DateOfBirth));
            }
        }
        public string PhoneNum
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                _phoneNum = value;
                NotifyPropertyChanged(nameof(PhoneNum));
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }
        public int Addr
        {
            get
            {
                return _addr;
            }
            set
            {
                _addr = value;
                NotifyPropertyChanged(nameof(Addr));
            }
        }

        public string Spec
        {
            get
            {
                return _spec;
            }
            set
            {
                _spec = value;
                NotifyPropertyChanged(nameof(Spec));
            }
        }

        public DentistInfoVM()
        {

        }



        public DentistInfoVM GetDentistInfo(string connectionString, DentistInfoVM dentistInfo)
        {
            int DenID = 1;
            string GetCustomerInfoQuery = "select MANS, HOTEN, NGSINH, SDT, EMAIL, MAPHONGKHAM, CHUYENMON from NHA_SI " + //HOTEN, NGSINH, GIOITINH, SDT, EMAIL, MAPHONGKHAM, CHUYENMON, MATKHAU
                                                "where MANS = @DenID";                                                      //1     2       3       4       5       6           7           8

            try
            {
                using (var conn = new SqlConnection(@connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetCustomerInfoQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                //var customerInfo = new CustomerInfoViewModel();

                                while (reader.Read())
                                {
                                    dentistInfo._denID = reader.GetInt32(0); // Assuming _denID is of type int
                                    dentistInfo._denName = reader.GetString(1);
                                    DateTime date = reader.GetDateTime(2);
                                    dentistInfo.DateOfBirth = DateOnly.FromDateTime(date);
                                    dentistInfo.PhoneNum = reader.GetString(4);
                                    dentistInfo.Addr = reader.GetInt32(6);
                                    dentistInfo.Email = reader.GetString(5);
                                    dentistInfo.Spec = reader.GetString(7);

                                }

                            }
                        }
                    }
                }
                return dentistInfo;

            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }
            return null;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
