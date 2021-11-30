using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class Tool
    {
        public Tool()
        {
        }
        public int IdTool { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
        public ToolType ToolType { get; set; }
    }
}
