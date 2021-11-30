using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier.SystemAdministration
{
    [Serializable]
    public class CertificateType
    {
        public CertificateType()
        {
        }
        public int IdCertificateType { get; set; }
        public string Name {get;set;}
        public string Description { get; set; }
    }

    public enum CertificateTypeEnum
    {
        Presupuesto = 1,
        Finalizacion = 2,
        Avance = 3,
        Adicional = 4,
    }
}
