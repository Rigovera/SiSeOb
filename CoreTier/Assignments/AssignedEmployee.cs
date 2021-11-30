using CoreTier.SystemAdministration;
using CoreTier.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.Assignments
{
    [Serializable]
    public class AssignedEmployee
    {
        public AssignedEmployee()
        {
        }
        public int IdAssignedEmployee { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public Nullable<System.DateTime> DateOfDeallocate { get; set; }
        public Employee Employee { get; set; }
        public AssignmentState AssignmentState { get; set; }
        public Work Work { get; set; }
    }
}
