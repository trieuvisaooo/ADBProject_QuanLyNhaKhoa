using System;


namespace ADB_QLNHAKHOA.ViewModels
{
    public class UserInfoViewModel: BaseViewModel
    {
        private int _id;
        private string _name;
        private DateOnly _birthday;
        private string _phone;
        private string _email;
        private string _password;

        public int Id {get; set;}
        public string Name {get; set;}
        
        public DateOnly Birthday {get { return _birthday; } 
            set { 
                _birthday = value;
                //OnPropertyChanged(nameof(Birthday));
                } 
            }

        public string Phone {
            get { 
                return _phone;
                } 
            set {  
                _phone = value;
                OnPropertyChanged(nameof(Phone));
                }
        }
        public string Email {get { return _email;} set { _email = value; OnPropertyChanged(nameof(Email));} }
        public string Password {get { return _password;} 
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public UserInfoViewModel() {}

    }
}
