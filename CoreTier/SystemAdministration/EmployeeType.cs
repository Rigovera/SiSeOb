using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class EmployeeType
    {
        public EmployeeType()
        {
        }
        public int IdEmployeeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
