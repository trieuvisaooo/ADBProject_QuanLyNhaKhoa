using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_QLNHAKHOA.Models
{
    public class CustomerM: UserM
    {
        public string Gender { get; set; }
        public string OralCondition { get; set; }
        public string Contraindication { get; set; }
        public string AlergyStatus { get; set; }

        public CustomerM(int id, string name, string password, string email, DateTime birthday, 
            string gender, string oralCondition, string 
            contraindication, string alergyStatus) : base(id, name, password, email, birthday)
        {
            Gender = gender;
            OralCondition = oralCondition;
            Contraindication = contraindication;
            AlergyStatus = alergyStatus;
        }
    }
}
