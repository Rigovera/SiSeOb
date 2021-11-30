using CoreTier.Certificates;
using CoreTier.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.CertificatesLogic
{
    public interface ICertificasteLogic
    {
        IList<Certificate> GetAllCertificates(Work work);
        void InsertCertificate(Certificate certificate);
        void UpdateCertificate(Certificate certificate);
    }
}
