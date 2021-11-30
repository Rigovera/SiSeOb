using CoreTier.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class CertificateArticle
    {
        public CertificateArticle()
        {
        }
        public int IdCertificateArticles { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public CertificateArticleItem CertificateArticleItem { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public List<ArticlePrices> ArticlePrices { get; set; }
    }
}
