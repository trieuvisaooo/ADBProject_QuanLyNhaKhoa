using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateOnly Birthday {get { return _birthday;} 
            set { _birthday = value;
                } 
            }
        public string Phone {
            get { 
                return _phone;
                } 
            set {  
                _phone = value;
                
                }
            }
        public string Email {get { return _email;} set { _email = value; } }
        public string Password {get { return _password;} 
            set
            {
                _password = value;
            }
        }

        public UserInfoViewModel() {}

    }
}
