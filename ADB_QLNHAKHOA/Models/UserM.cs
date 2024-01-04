using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.Models
{
    public class UserM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        
        public UserM(int id, string name, string password, string email, DateTime birthday)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Birthday = birthday;
        }
    }
}
