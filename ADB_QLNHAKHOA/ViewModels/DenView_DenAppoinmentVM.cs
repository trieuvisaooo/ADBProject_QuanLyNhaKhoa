using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.ViewModels
{
    public class DenView_DenAppoinmentVM : INotifyPropertyChanged
    {
        private int _appoID;
        private string _cusName;
        private int _cusID;
        private DateOnly _appoDate;
        private TimeOnly _appoTime;
        private string _note;

        public int AppoID
        {
            get
            {
                return _appoID;
            }
            set
            {
                _appoID = value;
                NotifyPropertyChanged(nameof(_appoID));
            }
        }
        public string CusName
        {
            get
            {
                return _cusName;
            }
            set
            {
                _cusName = value;
                NotifyPropertyChanged(nameof(CusName));
            }
        }
        public int CusID
        {
            get { return _cusID; }
            set
            {
                _cusID = value;
                NotifyPropertyChanged(nameof(CusID));
            }
        }
        public DateOnly AppoDate
        {
            get
            {
                return _appoDate;
            }
            set
            {
                _appoDate = value;
                NotifyPropertyChanged(nameof(AppoDate));
            }
        }
        public TimeOnly AppoTime
        {
            get
            {
                return _appoTime;
            }
            set
            {
                _appoTime = value;
                NotifyPropertyChanged(nameof(AppoTime));
            }
        }

        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                NotifyPropertyChanged(nameof(_note));
            }
        }


        public ObservableCollection<DenView_DenAppoinmentVM> GetAppointments(string connectionString, int denID)
        {
            string GetAppointmentQuery = "select CH.MACUOCHEN, CH.MABN, CH.TENBN, CH.NGAYHEN, CH.GIOHEN, CH.GHICHU from CUOC_HEN CH " +
                                                "where CH.NHASIKHAM = " + denID + " and  CH.TENBN is not null and CH.NGAYHEN is not null and CH.GIOHEN is not null and CH.GHICHU is not null" +
                                                " order by CH.NGAYHEN desc, CH.GIOHEN desc";


            var appointments = new ObservableCollection<DenView_DenAppoinmentVM>();
            try
            {
                Debug.WriteLine(GetAppointmentQuery);

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetAppointmentQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var DenAppointment = new DenView_DenAppoinmentVM();
                                    DenAppointment.AppoID = reader.GetInt32(0);
                                    DenAppointment.CusID = reader.GetInt32(1);
                                    DenAppointment.CusName = reader.GetString(2);
                                    DateTime date = reader.GetDateTime(3);
                                    DenAppointment.AppoDate = DateOnly.FromDateTime(date);
                                    TimeSpan time = reader.GetTimeSpan(4);
                                    DenAppointment.AppoTime = TimeOnly.FromTimeSpan(time);
                                    DenAppointment.Note = reader.GetString(5);

                                    appointments.Add(DenAppointment);
                                }
                            }
                        }
                    }
                }
                return appointments;
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
