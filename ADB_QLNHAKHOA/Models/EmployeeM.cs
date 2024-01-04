using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.Models
{
    public class EmployeeM: UserM
    {
        public EmployeeM(int id, string name, string password, string email, DateTime birthday) : base(id, name, password, email, birthday) { }
    }
}
