using CoreTier.SystemAdministration;
using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.SystemAdministrationLogic
{
    public class SystemAdministrationLogic : ISystemAdministrationLogic
    {
        private ISystemAdministrationDAO _systemAdministrationDataAcces;
        public SystemAdministrationLogic()
        {
            _systemAdministrationDataAcces = new SystemAdministrationDAO();

        }

        #region Employees
        public IList<Employee> GetAllEmployeesWhoseFirstNameContains(string filter)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllEmployees();
                result = result.Where(x => x.FirstName.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployeesWhoseFirstNameContains_Logic", ex);
                throw ex;
            }
        }
        public IList<Employee> GetAllEmployeesWhoseLastNameContains(string filter)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllEmployees();
                result = result.Where(x => x.LastName.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployeesWhoseLastNameContains_Logic", ex);
                throw ex;
            }
        }
        public IList<Employee> GetAllEmployeesWhoseDNIContains(string filter)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllEmployees();
                result = result.Where(x => x.DNI.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployeesWhoseDNIContains_Logic", ex);
                throw ex;
            }
        }
        public IList<Employee> GetAllEmployessByAdmissionDate(DateTime date)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllEmployees();
                result = result.Where(x => x.AdmissionDate.Date == date.Date).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployessByAdmissionDate_Logic", ex);
                throw ex;
            }
        }
        public IList<Employee> GetAllEmployessByEmployeeType(int idEmployee)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllEmployees();
                result = result.Where(x => x.EmployeeType.IdEmployeeType == idEmployee).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployessByEmployeeType_Logic", ex);
                throw ex;
            }
        }


        public IList<Employee> GetAllEmployees()
        {
            var result = _systemAdministrationDataAcces.GetAllEmployees();
            return result;
        }
        public void InsertEmployee(Employee employee)
        {
            try
            {
                _systemAdministrationDataAcces.InsertEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteEmployee(Employee employee)
        {
            _systemAdministrationDataAcces.DeleteEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            try { _systemAdministrationDataAcces.UpdateEmployee(employee); }
            catch(Exception ex)
            {
                Logger.Log.Error("UpdateEmployee_Logic", ex);
            }
        }

        public IList<Employee> GetAllEmployeesByType(int idEmployeeType)
        {
            var result = _systemAdministrationDataAcces.GetAllEmployees();
            result = result.Where(x => x.EmployeeType.IdEmployeeType == idEmployeeType).ToList();
            return result;
        }
        #endregion

        #region EmployeeTypes
        public IList<EmployeeType> GetAllEmployeeTypes()
        {
            var result = _systemAdministrationDataAcces.GetAllEmployeeTypes();
            return result;
        }
        public void InsertEmployeeType(EmployeeType employeeType)
        {
            _systemAdministrationDataAcces.InsertEmployeeType(employeeType);
        }
        public void DeleteEmployeeType(EmployeeType employeeType)
        {
            _systemAdministrationDataAcces.DeleteEmployeeType(employeeType);
        }
        public void UpdateEmployeeType (EmployeeType employeeType)
        {
            _systemAdministrationDataAcces.UpdateEmployeeType(employeeType);
        }
        #endregion

        #region Location
        public IList<Location> GetAllLocations()
        {
            var result = _systemAdministrationDataAcces.GetAllLocations();
            return result;
        }
        public void InsertLocation(Location location)
        {
            _systemAdministrationDataAcces.InsertLocation(location);
        }
        public void DeleteLocation(Location location)
        {
            _systemAdministrationDataAcces.DeleteLocation(location);
        }
        public void UpdateLocation(Location location)
        {
            _systemAdministrationDataAcces.UpdateLocation(location);
        }
        #endregion

        #region Tools
        public IList<Tool> GetAllToolsWhoseNameContains(string filter)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllTools();
                result = result.Where(x => x.Name.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllToolsWhoseNameContains_Logic", ex);
                throw ex;
            }
        }
        public IList<Tool> GetAllToolsWhoseBrandContains(string filter)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllTools();
                result = result.Where(x => x.Brand.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllToolsWhoseBrandContains_Logic", ex);
                throw ex;
            }
        }
        public IList<Tool> GetAllWorksByWorkType(int idToolType)
        {
            try
            {
                var result = _systemAdministrationDataAcces.GetAllTools();
                result = result.Where(x => x.ToolType.IdToolType == idToolType).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByWorkType_Logic", ex);
                throw ex;
            }
        }

        public IList<Tool> GetAllTools()
        {
            var result = _systemAdministrationDataAcces.GetAllTools();
            return result;
        }
        public void InsertTool(Tool tool)
        {
            _systemAdministrationDataAcces.InsertTool(tool);
        }
        public void DeleteTool(Tool tool)
        {
            _systemAdministrationDataAcces.DeleteTool(tool);
        }
        public void UpdateTool(Tool tool)
        {
            try { _systemAdministrationDataAcces.UpdateTool(tool); }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateTool_Logic", ex);
            }
        }

        public IList<Tool> GetAllToolsByType(int idToolType)
        {
            var result = _systemAdministrationDataAcces.GetAllTools();
            result = result.Where(x => x.ToolType.IdToolType == idToolType).ToList();
            return result;
        }
        #endregion

        #region ToolTypes
        public IList<ToolType> GetAllToolTypes()
        {
            var result = _systemAdministrationDataAcces.GetAllToolTypes();
            return result;
        }
        public void InsertToolType(ToolType toolType)
        {
            _systemAdministrationDataAcces.InsertToolType(toolType);
        }
        public void DeleteToolType(ToolType toolType)
        {
            _systemAdministrationDataAcces.DeleteToolType(toolType);
        }
        public void UpdateToolType(ToolType toolType)
        {
            try { _systemAdministrationDataAcces.UpdateToolType(toolType); }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateToolType_Logic", ex);
            }
        }
        #endregion

        #region WorkType
        public IList<WorkType> GetAllWorkTypes()
        {
            var result = _systemAdministrationDataAcces.GetAllWorkTypes();
            return result;
        }
        public void InsertWorkType(WorkType workType)
        {
            _systemAdministrationDataAcces.InsertWorkType(workType);
        }
        public void DeleteWorkType(WorkType workType)
        {
            _systemAdministrationDataAcces.DeleteWorkType(workType);
        }
        public void UpdateWorkType(WorkType workType)
        {
            _systemAdministrationDataAcces.UpdateWorkType(workType);
        }
        #endregion

        #region CertificateArticles 
        public void UpdateUnitCostByItem(int idCertificateArticleItem, decimal Percent, string sign, int idPriceList)
        {
            var CertificateArticles = _systemAdministrationDataAcces
                .GetCertificateArticlesByIdCertificateArticleItem(idCertificateArticleItem);
            decimal newUnitCost = 0;
            foreach (var item in CertificateArticles)
            {
                foreach(var subitem in item.ArticlePrices.Where(x => x.PriceList.IdPriceList == idPriceList))
                {
                    if (sign == "+")
                        newUnitCost = subitem.UnitCost + ((subitem.UnitCost / 100) * Percent);
                    else if (sign == "-")
                        newUnitCost = subitem.UnitCost - ((subitem.UnitCost / 100) * Percent);

                    subitem.UnitCost = newUnitCost;
                    _systemAdministrationDataAcces.UpdateArticlePrice(subitem);
                }
            }
        }
        public IList<CertificateArticle> GetAllCertificateArticles()
        {
            var result = _systemAdministrationDataAcces.GetAllCertificateArticles();
            return result;
        }
        public void InsertCertificateArticle(CertificateArticle certificateArticle)
        {
            try
            {
                _systemAdministrationDataAcces.InsertCertificateArticle(certificateArticle);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticle_Logic", ex);
                throw ex;
            }
        }
        public void DeleteCertificateArticle(CertificateArticle certificateArticle)
        {
            _systemAdministrationDataAcces.DeleteCertificateArticle(certificateArticle);
        }
        public void UpdateCertificateArticle(CertificateArticle certificateArticle)
        {
            try
            {
                _systemAdministrationDataAcces.UpdateCertificateArticle(certificateArticle);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificateArticle", ex);
                throw ex;
            }
        }
        public IList<CertificateArticle> GetAllCertificateArticlesByCertificateArticleitem(int idCertificateArticleItem)
        {
            var result = _systemAdministrationDataAcces.GetAllCertificateArticles();
            result = result.Where(x => x.CertificateArticleItem.IdCertificateArticleItem == idCertificateArticleItem).ToList();
            return result;
        }

        public IList<CertificateArticle> GetAllCertificateArticlesWhoseNameContains(string filter)
        {
            var result = _systemAdministrationDataAcces.GetAllCertificateArticles();
            result = result.Where(x => x.Name.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            return result;
        }
        #endregion

        #region CertificateArticleItems
        public IList<CertificateArticleItem> GetAllCertificateArticleItem()
        {
            var result = _systemAdministrationDataAcces.GetAllCertificateArticleItem();
            return result;
        }
        public void InsertCertificateArticleItem(CertificateArticleItem certificateArticleItem)
        {
            try
            {
                _systemAdministrationDataAcces.InsertCertificateArticleItem(certificateArticleItem);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticleItem_Logic", ex);
                throw ex;
            }
        }
        public void DeleteCertificateArticleItem(CertificateArticleItem certificateArticleItem)
        {
            _systemAdministrationDataAcces.DeleteCertificateArticleItem(certificateArticleItem);
        }
        public void UpdateCertificateArticleItem(CertificateArticleItem certificateArticleItem)
        {
            try
            {
                _systemAdministrationDataAcces.UpdateCertificateArticleItem(certificateArticleItem);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificateArticleItem_Logic", ex);
            }

        }
        #endregion

        #region CertificateTypes
        public IList<CertificateType> GetAllCertificateTypes()
        {
            var result = _systemAdministrationDataAcces.GetAllCertificateTypes();
            return result;
        }
        public void InsertCertificateType(CertificateType certificateType)
        {
            _systemAdministrationDataAcces.InsertCertificateType(certificateType);
        }
        public void DeleteCertificateType(CertificateType certificateType)
        {
            _systemAdministrationDataAcces.DeleteCertificateType(certificateType);
        }
        public void UpdateCertificateType(CertificateType certificateType)
        {
            _systemAdministrationDataAcces.UpdateCertificateType(certificateType);
        }
        #endregion

        #region MeasurementUnit
        public IList<MeasurementUnit> GetAllMeasurementUnit()
        {
            var result = _systemAdministrationDataAcces.GetAllMeasurementUnits();
            return result;
        }
        public void InsertMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _systemAdministrationDataAcces.InsertMeasurementUnit(measurementUnit);
        }
        public void DeleteMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _systemAdministrationDataAcces.DeleteMeasurementUnit(measurementUnit);
        }
        public void UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _systemAdministrationDataAcces.UpdateMeasurementUnit(measurementUnit);
        }
        #endregion

        #region MoneyMovementType
        public IList<MoneyMovementType> GetAllMoneyMovementType()
        {
            var result = _systemAdministrationDataAcces.GetAllMoneyMovementTypes();
            return result;
        }
        public void InsertMoneyMovementType(MoneyMovementType moneyMovementType)
        {
            _systemAdministrationDataAcces.InsertMoneyMovementType(moneyMovementType);
        }
        public void DeleteMoneyMovementType(MoneyMovementType moneyMovementType)
        {
            _systemAdministrationDataAcces.DeleteMoneyMovementType(moneyMovementType);
        }
        public void UpdateMoneyMovementType(MoneyMovementType moneyMovementType)
        {
            _systemAdministrationDataAcces.UpdateMoneyMovementType(moneyMovementType);
        }
        #endregion

        #region PriceList
        public IList<PriceList> GetAllPriceLists()
        {
            var result = _systemAdministrationDataAcces.GetAllPriceLists();
            return result;
        }
        public void InsertPriceList(PriceList priceList)
        {
            _systemAdministrationDataAcces.InsertPriceList(priceList);
        }
        public void DeletePriceList(PriceList priceList)
        {
            _systemAdministrationDataAcces.DeletePriceList(priceList);
        }
        public void UpdatePriceList(PriceList priceList)
        {
            _systemAdministrationDataAcces.UpdatePriceList(priceList);
        }
        #endregion

        #region Articleprices
        public IList<ArticlePrices> GetArticlePricesByIdCertificateArticle(int IdCertificateArticle)
        {
           var result = _systemAdministrationDataAcces.GetArticlePricesByIdCertificateArticle(IdCertificateArticle);
            return result;
        }
        public IList<ArticlePrices> GetArticlePricesByIdCertificateArticle()
        {
            var result = _systemAdministrationDataAcces.GetAllArticlePrices();
            return result;
        }
        public void InsertPriceList(ArticlePrices articlePrices)
        {
            _systemAdministrationDataAcces.InsertArticlePrice(articlePrices);
        }
        public void DeleteArticlePrice(ArticlePrices articlePrices)
        {
            _systemAdministrationDataAcces.DeleteArticlePrice(articlePrices);
        }
        public void UpdateArticlePrice(ArticlePrices articlePrices)
        {
            _systemAdministrationDataAcces.UpdateArticlePrice(articlePrices);
        }
        #endregion

        public void BackupDB()
        {
            _systemAdministrationDataAcces.BackupDB();
        }
    }
}
