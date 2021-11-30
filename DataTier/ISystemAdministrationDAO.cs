using CoreTier.SystemAdministration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public interface ISystemAdministrationDAO
    {
        IList<Employee> GetAllEmployees();
        void InsertEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);

        IList<EmployeeType> GetAllEmployeeTypes();
        void InsertEmployeeType(EmployeeType employee);
        void DeleteEmployeeType(EmployeeType employee);
        void UpdateEmployeeType(EmployeeType employeeType);

        IList<Location> GetAllLocations();
        void InsertLocation(Location location);
        void DeleteLocation(Location location);
        void UpdateLocation(Location location);

        IList<Tool> GetAllTools();
        void InsertTool(Tool tool);
        void DeleteTool(Tool tool);
        void UpdateTool(Tool tool);

        IList<ToolType> GetAllToolTypes();
        void InsertToolType(ToolType toolType);
        void DeleteToolType(ToolType toolType);
        void UpdateToolType(ToolType toolType);

        IList<WorkType> GetAllWorkTypes();
        void InsertWorkType(WorkType workType);
        void DeleteWorkType(WorkType workType);
        void UpdateWorkType(WorkType workType);

        IList<MeasurementUnit> GetAllMeasurementUnits();
        void InsertMeasurementUnit(MeasurementUnit measurementUnit);
        void DeleteMeasurementUnit(MeasurementUnit measurementUnit);
        void UpdateMeasurementUnit(MeasurementUnit measurementUnit);

        IList<CertificateArticleItem> GetAllCertificateArticleItem();
        void InsertCertificateArticleItem(CertificateArticleItem certificateArticleItem);
        void DeleteCertificateArticleItem(CertificateArticleItem certificateArticleItem);
        void UpdateCertificateArticleItem(CertificateArticleItem certificateArticleItem);

        IList<CertificateArticle> GetCertificateArticlesByIdCertificateArticleItem(int idCertificateArticleItem);
        IList<CertificateArticle> GetAllCertificateArticles();
        void InsertCertificateArticle(CertificateArticle certificateArticle);
        void DeleteCertificateArticle(CertificateArticle certificateArticle);
        void UpdateCertificateArticle(CertificateArticle certificateArticle);

        IList<MoneyMovementType> GetAllMoneyMovementTypes();
        void InsertMoneyMovementType(MoneyMovementType accountingMovementType);
        void DeleteMoneyMovementType(MoneyMovementType accountingMovementType);
        void UpdateMoneyMovementType(MoneyMovementType accountingMovementType);

        IList<CertificateType> GetAllCertificateTypes();
        void InsertCertificateType(CertificateType certificateType);
        void DeleteCertificateType(CertificateType certificateType);
        void UpdateCertificateType(CertificateType certificateType);

        IList<PriceList> GetAllPriceLists();
        void InsertPriceList(PriceList priceList);
        void DeletePriceList(PriceList priceList);
        void UpdatePriceList(PriceList priceList);

        IList<ArticlePrices> GetArticlePricesByIdCertificateArticle(int IdCertificateArticle);
        IList<ArticlePrices> GetAllArticlePrices();
        void InsertArticlePrice(ArticlePrices articlePrices);
        void DeleteArticlePrice(ArticlePrices articlePrices);
        void UpdateArticlePrice(ArticlePrices articlePrices);

        void BackupDB();
    }
}
