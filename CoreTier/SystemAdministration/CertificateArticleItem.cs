using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class CertificateArticleItem
    {
        public CertificateArticleItem()
        {
        }
        public int IdCertificateArticleItem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
