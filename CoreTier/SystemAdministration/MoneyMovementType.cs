using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class MoneyMovementType
    {
        public MoneyMovementType()
        {
        }
        public int IdMoneyMovementType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MovementSign Sign { get; set; }
    }

}
