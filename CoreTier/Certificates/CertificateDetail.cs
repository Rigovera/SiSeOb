using CoreTier.SystemAdministration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.Certificates
{
    [Serializable]
    public class CertificateDetail
    {
        public CertificateDetail()
        {
        }
        public int IdCertificateDetail { get; set; }
        public Certificate Certificate { get; set; }
        public CertificateArticle CertificateArticle { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public decimal UnitCost { get; set; }
    }
}
