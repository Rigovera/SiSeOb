using CoreTier.Certificates;
using CoreTier.Works;
using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.CertificatesLogic
{
    public class CertificatesLogic:ICertificasteLogic
    {
        ICertificatesDAO _certificateDAO { get; set; }
        public CertificatesLogic()
        {
            _certificateDAO = new CertificatesDAO();
        }
        public IList<Certificate> GetAllCertificates(Work work)
        {
            try
            {
                var result = _certificateDAO.GetAllCertificatesFromOnewWork(work)
                    .OrderBy(x => x.CreationDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllCertificates_Logic", ex);
                throw ex;
            }
           
        }
        public void InsertCertificate(Certificate certificate)
        {
            try
            {
                _certificateDAO.InsertCertificate(certificate);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificate_Logic", ex);
                throw ex;
            }            
        }
        public void UpdateCertificate(Certificate certificate)
        {
            try
            {
                certificate.ModificationDate = DateTime.Now;
                _certificateDAO.UpdateCertificate(certificate);

                var currentDetail = _certificateDAO.GetAllCertificateDetailFromOneCertificate(certificate);
                foreach (var item in currentDetail)
                {
                    if (!certificate.CertificateDetail.Any(x => x.IdCertificateDetail == item.IdCertificateDetail &&
                                                                x.Quantity == item.Quantity))
                    {
                        _certificateDAO.DeleteCertificateDetail(item);
                    }
                }

                foreach (var item in certificate.CertificateDetail)
                {
                    if (item.IdCertificateDetail > 0)
                        _certificateDAO.UpdateCertificateDetail(item);
                    else
                        _certificateDAO.InsertCertificateDetail(item, certificate.IdCertificate);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificate_Logic", ex);
                throw;
            }            
        }
    }
}
