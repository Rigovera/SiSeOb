using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class Employee
    {
        public Employee()
        {
        }
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string DNI { get; set; }
        public string Cuil { get; set; }
        public DateTime AdmissionDate { get; set; }           
        public EmployeeType EmployeeType { get; set; }     
        public decimal AgreedSalary { get; set; }
    }
}
