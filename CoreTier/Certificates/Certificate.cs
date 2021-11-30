using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTier.SystemAdministration;
using CoreTier.Works;

namespace CoreTier.Certificates
{
    [Serializable]
    public class Certificate
    {
        public Certificate()
        {
        }
        public int IdCertificate { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal WorkProgress { get; set; }
        public DateTime ModificationDate { get; set; }
        public CertificateType CertificateType { get; set; }
        public List<CertificateDetail> CertificateDetail { get; set; }
        public Work Work { get; set; }
    }
}
