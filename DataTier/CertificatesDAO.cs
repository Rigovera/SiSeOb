using CoreTier.Certificates;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using DataTier.EntityModel;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTier
{
    public class CertificatesDAO :DataRepository, ICertificatesDAO
    {
        public IList<Certificate> GetAllCertificatesFromOnewWork(Work work)
        {
            try
            {
                var result = new List<Certificate>();

                var certificadosDeObra = _siseobDB.certificates.Include("certificatetype")
                                                                .Include("work")
                                                                .Include(x => x.certificatedetails)
                                                                .Where(x => x.IdWork == work.IdWork).ToList();
                foreach (var item in certificadosDeObra)
                {
                    var certificate = new Certificate();
                    certificate.InjectFrom(item);
                    certificate.Work = new Work();
                    certificate.Work.InjectFrom(item.work);
                    certificate.CertificateType = new CertificateType();
                    certificate.CertificateType.InjectFrom(item.certificatetype);

                    foreach (var subitem in item.certificatedetails)
                    {
                        var articulo = new CertificateDetail();
                        articulo.InjectFrom(subitem);
                        articulo.CertificateArticle = new CertificateArticle();
                        articulo.CertificateArticle.MeasurementUnit = new MeasurementUnit();
                        articulo.CertificateArticle.MeasurementUnit.InjectFrom(subitem.certificatearticle.measurementunit);
                        articulo.CertificateArticle.CertificateArticleItem = new CertificateArticleItem();
                        articulo.CertificateArticle.CertificateArticleItem.InjectFrom(subitem.certificatearticle.certificatearticleitem);
                        articulo.CertificateArticle.InjectFrom(subitem.certificatearticle);
                        if (certificate.CertificateDetail == null)
                            certificate.CertificateDetail = new List<CertificateDetail>();
                        certificate.CertificateDetail.Add(articulo);
                    }
                    result.Add(certificate);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllCertificatesFromOnewWork_DAO", ex);
                throw ex;
            }            
        }
        public void InsertCertificate (Certificate certificate)
        {
            try
            {
                var certificateEntity = new certificate();
                certificateEntity.InjectFrom(certificate);
                certificateEntity.IdWork = certificate.Work.IdWork;
                certificateEntity.IdCertificateType = certificate.CertificateType.IdCertificateType;
                _siseobDB.certificates.Add(certificateEntity);
                _siseobDB.SaveChanges();
                var idCertificate = certificateEntity.IdCertificate;

                foreach(var item in certificate.CertificateDetail)
                {
                    if (item.IdCertificateDetail == 0)
                        InsertCertificateDetail(item, idCertificate);
                }               
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificate_DAO", ex);
                throw ex;
            }
        }
        public void UpdateCertificate(Certificate certificate)
        {
            try
            {
                var certificateEntity = _siseobDB.certificates.Find(certificate.IdCertificate);
                if (certificateEntity != null)
                {
                    var creationDate = certificateEntity.CreationDate;
                    certificateEntity.InjectFrom(certificate);
                    certificateEntity.CreationDate = creationDate;
                    _siseobDB.Entry(certificateEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();                                   
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificate_DAO", ex);
                throw ex;
            }
        }


        public IList<CertificateDetail> GetAllCertificateDetailFromOneCertificate(Certificate certificate)
        {
            try
            {
                var result = new List<CertificateDetail>();

                var certificateDetailList = _siseobDB.certificatedetails.Include("certificate")
                                                              .Include("certificatearticle")
                                                              .Where(x => x.IdCertificate == certificate.IdCertificate)
                                                              .ToList();
                foreach (var item in certificateDetailList)
                {
                    var articleDetail = new CertificateDetail();
                    articleDetail.InjectFrom(item);
                    articleDetail.CertificateArticle = new CertificateArticle();
                    articleDetail.CertificateArticle.InjectFrom(item.certificatearticle);
                    articleDetail.Certificate = new Certificate();
                    articleDetail.Certificate.InjectFrom(item.certificate);
                    result.Add(articleDetail);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllCertificateDetailFromOneCertificate_DAO", ex);
                throw ex;
            }          
        }
        public void UpdateCertificateDetail(CertificateDetail certificateDetail)
        {
            try
            {
                var certificateDetailEntity = _siseobDB.certificatedetails.Find(certificateDetail.IdCertificateDetail);
                if (certificateDetailEntity != null)
                {
                    certificateDetailEntity.InjectFrom(certificateDetail);
                    _siseobDB.Entry(certificateDetailEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificateDetail_DAO", ex);
                throw ex;
            }
        }
        public void InsertCertificateDetail(CertificateDetail certificateDetail, int IdCertificate)
        {
            try
            {
                var certificateDetailEntity = new certificatedetail();
                certificateDetailEntity.InjectFrom(certificateDetail);
                certificateDetailEntity.IdCertificate = IdCertificate;
                certificateDetailEntity.IdCertificateArticles = certificateDetail.CertificateArticle.IdCertificateArticles;
                _siseobDB.certificatedetails.Add(certificateDetailEntity);
                _siseobDB.SaveChanges();
            }
            catch(Exception ex)
            {
                Logger.Log.Error("InsertCertificateDetail_DAO", ex);
                throw ex;
            }            
        }
        public void DeleteCertificateDetail(CertificateDetail certificateDetail)
        {
            try
            {
                var certificateDetailEntity = _siseobDB.certificatedetails.Find(certificateDetail.IdCertificateDetail);             
                _siseobDB.Entry(certificateDetailEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.certificatedetails.Remove(certificateDetailEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateDetail_DAO", ex);
                throw ex;
            }
        }
    }
}
