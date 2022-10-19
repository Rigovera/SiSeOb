using CoreTier.Certificates;
using CoreTier.Works;

using System.Collections.Generic;

namespace DataTier
{
    public interface ICertificatesDAO
    {
        IList<Certificate> GetAllCertificatesFromOnewWork(Work work);
        void InsertCertificate(Certificate certificate);
        void UpdateCertificate(Certificate certificate);

        IList<CertificateDetail> GetAllCertificateDetailFromOneCertificate(Certificate certificate);
        void UpdateCertificateDetail(CertificateDetail certificateDetail);
        void InsertCertificateDetail(CertificateDetail certificateDetail, int IdCertificate);
        void DeleteCertificateDetail(CertificateDetail certificateDetail);
    }
}
