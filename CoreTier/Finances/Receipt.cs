using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.Finances
{
    public class Receipt
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<ReceiptDetail> ReceiptDetail { get; set; }
    }
}
