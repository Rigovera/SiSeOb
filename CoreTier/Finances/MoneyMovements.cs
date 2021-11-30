using CoreTier.SystemAdministration;
using CoreTier.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.Finances
{
    [Serializable]
    public class MoneyMovement
    {
        public MoneyMovement()
        {
        }
        public int IdMoneyMovement { get; set; }
        public decimal Amount { get; set; }
        public MoneyMovementType MoneyMovementType { get; set; }  
        public Work Work { get; set; }    
    }
}
