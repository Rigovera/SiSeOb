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
    public class AssignedTool
    {
        public AssignedTool()
        {
        }
        public int IdAssignedTool { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public Nullable<System.DateTime> DateOfDeallocate { get; set; }
        public Tool Tool { get; set; }
        public AssignmentState AssignmentState { get; set; }
        public Work Work { get; set; }
    }
}
