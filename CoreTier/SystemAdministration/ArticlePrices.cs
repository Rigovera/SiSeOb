using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class ArticlePrices
    {
        public ArticlePrices()
        {
        }
        public int IdArticlePrices { get; set; }
        public decimal UnitCost { get; set; }
        public PriceList PriceList { get; set; }
        public CertificateArticle CertificateArticle { get; set; }
    }
}
