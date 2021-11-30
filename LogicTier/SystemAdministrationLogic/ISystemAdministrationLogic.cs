using CoreTier.SystemAdministration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.SystemAdministrationLogic
{
    public interface ISystemAdministrationLogic
    {
        IList<Employee> GetAllEmployeesWhoseFirstNameContains(string filter);
        IList<Employee> GetAllEmployeesWhoseLastNameContains(string filter);
        IList<Employee> GetAllEmployeesWhoseDNIContains(string filter);
        IList<Employee> GetAllEmployessByAdmissionDate(DateTime date);
        IList<Employee> GetAllEmployessByEmployeeType(int idEmployee);
        IList<Employee> GetAllEmployees();
        void InsertEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        IList<Employee> GetAllEmployeesByType(int idEmployeeType);

        IList<EmployeeType> GetAllEmployeeTypes();
        void InsertEmployeeType(EmployeeType employeeType);
        void DeleteEmployeeType(EmployeeType employeeType);
        void UpdateEmployeeType(EmployeeType employeeType);

        IList<Tool> GetAllToolsWhoseNameContains(string filter);
        IList<Tool> GetAllToolsWhoseBrandContains(string filter);
        IList<Tool> GetAllWorksByWorkType(int idToolType);
        IList<Tool> GetAllTools();
        void InsertTool(Tool tool);
        void DeleteTool(Tool tool);
        void UpdateTool(Tool tool);
        IList<Tool> GetAllToolsByType(int idToolType);

        IList<ToolType> GetAllToolTypes();
        void InsertToolType(ToolType toolType);
        void DeleteToolType(ToolType toolType);
        void UpdateToolType(ToolType toolType);

        IList<MeasurementUnit> GetAllMeasurementUnit();
        void InsertMeasurementUnit(MeasurementUnit measurementUnit);
        void DeleteMeasurementUnit(MeasurementUnit measurementUnit);
        void UpdateMeasurementUnit(MeasurementUnit measurementUnit);

        IList<CertificateArticleItem> GetAllCertificateArticleItem();
        void InsertCertificateArticleItem(CertificateArticleItem certificateArticleItem);
        void DeleteCertificateArticleItem(CertificateArticleItem certificateArticleItem);
        void UpdateCertificateArticleItem(CertificateArticleItem certificateArticleItem);

        IList<CertificateArticle> GetAllCertificateArticles();
        void InsertCertificateArticle(CertificateArticle certificateArticle);
        void DeleteCertificateArticle(CertificateArticle certificateArticle);
        void UpdateCertificateArticle(CertificateArticle certificateArticle);
        void UpdateUnitCostByItem(int idCertificateArticleItem, decimal Percent, string sign, int idPriceList);
        IList<CertificateArticle> GetAllCertificateArticlesByCertificateArticleitem(int idCertificateArticleItem);
        IList<CertificateArticle> GetAllCertificateArticlesWhoseNameContains(string filter);

        IList<MoneyMovementType> GetAllMoneyMovementType();
        void InsertMoneyMovementType(MoneyMovementType moneyMovementType);
        void DeleteMoneyMovementType(MoneyMovementType moneyMovementType);
        void UpdateMoneyMovementType(MoneyMovementType moneyMovementType);

        IList<WorkType> GetAllWorkTypes();
        void InsertWorkType(WorkType workType);
        void DeleteWorkType(WorkType workType);
        void UpdateWorkType(WorkType workType);

        IList<Location> GetAllLocations();
        void InsertLocation(Location location);
        void DeleteLocation(Location location);
        void UpdateLocation(Location location);

        IList<CertificateType> GetAllCertificateTypes();
        void InsertCertificateType(CertificateType certificateType);
        void DeleteCertificateType(CertificateType certificateType);
        void UpdateCertificateType(CertificateType certificateType);

        IList<PriceList> GetAllPriceLists();
        void InsertPriceList(PriceList priceList);
        void DeletePriceList(PriceList priceList);
        void UpdatePriceList(PriceList priceList);

        IList<ArticlePrices> GetArticlePricesByIdCertificateArticle(int IdCertificateArticle);
        IList<ArticlePrices> GetArticlePricesByIdCertificateArticle();
        void InsertPriceList(ArticlePrices articlePrices);
        void DeleteArticlePrice(ArticlePrices articlePrices);
        void UpdateArticlePrice(ArticlePrices articlePrices);
        

        void BackupDB();
    }
}
