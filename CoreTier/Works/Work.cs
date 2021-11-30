using CoreTier.SystemAdministration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.Works
{
    [Serializable]
    public class Work
    {
        public Work()
        {
        }
        public int IdWork { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> FinishDate { get; set; }
        public DateTime PossibleEndDate { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public WorkType WorkType { get; set; }
        public Client Client { get; set; }
    }
}
