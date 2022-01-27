using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using CoreTier.Certificates;
using DataTier.EntityModel;
using CoreTier.SystemAdministration;
using MySql.Data.MySqlClient;
using System.Data.Entity;


namespace DataTier
{
    public class SystemAdministrationDAO : DataRepository, ISystemAdministrationDAO
    {
        #region Employees
        public IList<Employee> GetAllEmployees()
        {
            try
            {
                var result = new List<Employee>();

                foreach (var item in _siseobDB.employees.Include("employeetype"))
                {
                    var employee = new Employee();
                    employee.EmployeeType = new EmployeeType();
                    employee.InjectFrom(item);
                    employee.EmployeeType.InjectFrom(item.employeetype);
                    result.Add(employee);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployees_DAO", ex);
                throw ex;
            }

        }
        public void InsertEmployee(Employee employee)
        {
            try
            {
                var employeeEntity = new employee();
                employeeEntity.InjectFrom(employee);
                employeeEntity.IdEmployeeType = employee.EmployeeType.IdEmployeeType;
                _siseobDB.employees.Add(employeeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertEmployee_DAO", ex);
                throw ex;
            }
        }
        public void DeleteEmployee(Employee employee)
        {
            try
            {
                var employeeEntity = new employee();
                employeeEntity.InjectFrom(employee);
                _siseobDB.employees.Remove(employeeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteEmployee_DAO", ex);
                throw ex;
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeEntity = _siseobDB.employees.Find(employee.IdEmployee);
                if (employeeEntity != null)
                {
                    employeeEntity.InjectFrom(employee);
                    employeeEntity.IdEmployeeType = employee.EmployeeType.IdEmployeeType;
                    _siseobDB.Entry(employeeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateEmployee_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region EmployeeTypes
        public IList<EmployeeType> GetAllEmployeeTypes()
        {
            try
            {
                var result = new List<EmployeeType>();
                foreach (var item in _siseobDB.employeetypes)
                {
                    var employeeType = new EmployeeType();
                    employeeType.InjectFrom(item);
                    result.Add(employeeType);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllEmployeeTypes_DAO", ex);
                throw ex;
            }

        }
        public void InsertEmployeeType(EmployeeType employeeType)
        {
            try
            {
                var employeeTypeEntity = new employeetype();
                employeeTypeEntity.InjectFrom(employeeType);
                _siseobDB.employeetypes.Add(employeeTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertEmployeeType_DAO", ex);
                throw ex;
            }
        }
        public void DeleteEmployeeType(EmployeeType employeeType)
        {
            try
            {
                var employeeTypeEntity = new employeetype();
                employeeTypeEntity.InjectFrom(employeeType);
                _siseobDB.Entry(employeeTypeEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.employeetypes.Remove(employeeTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteEmployeeType_DAO", ex);
                throw ex;
            }
        }
        public void UpdateEmployeeType(EmployeeType employeeType)
        {
            try
            {
                var employeeTypeEntity = _siseobDB.employeetypes
                    .Find(employeeType.IdEmployeeType);
                if (employeeTypeEntity != null)
                {
                    employeeTypeEntity.InjectFrom(employeeType);
                    _siseobDB.Entry(employeeTypeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateEmployeeType_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region Locations
        public IList<Location> GetAllLocations()
        {
            try
            {
                var result = new List<Location>();

                foreach (var item in _siseobDB.locations)
                {
                    var location = new Location();
                    location.InjectFrom(item);
                    result.Add(location);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllLocations_DAO", ex);
                throw ex;
            }
        }
        public void InsertLocation(Location location)
        {
            try
            {
                var locationEntity = new location();
                locationEntity.InjectFrom(location);
                _siseobDB.locations.Add(locationEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertLocation_DAO", ex);
                throw ex;
            }

        }
        public void DeleteLocation(Location location)
        {
            try
            {
                var locationEntity = new location();
                locationEntity.InjectFrom(location);
                _siseobDB.locations.Remove(locationEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteLocation_DAO", ex);
                throw ex;
            }
        }
        public void UpdateLocation(Location location)
        {
            try
            {
                var locationEntity = _siseobDB.locations.Find(location.IdLocation);
                if (locationEntity != null)
                {
                    locationEntity.InjectFrom(location);
                    _siseobDB.Entry(locationEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateLocation_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region MeasurementUnits
        public IList<MeasurementUnit> GetAllMeasurementUnits()
        {
            try
            {
                var result = new List<MeasurementUnit>();

                foreach (var item in _siseobDB.measurementunits)
                {
                    var measurementUnit = new MeasurementUnit();
                    measurementUnit.InjectFrom(item);
                    result.Add(measurementUnit);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllMeasurementUnits_DAO", ex);
                throw ex;
            }
        }
        public void InsertMeasurementUnit(MeasurementUnit measurementUnit)
        {
            try
            {
                var measurementUnitEntity = new measurementunit();
                measurementUnitEntity.InjectFrom(measurementUnit);
                _siseobDB.measurementunits.Add(measurementUnitEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertMeasurementUnit", ex);
                throw ex;
            }
        }
        public void DeleteMeasurementUnit(MeasurementUnit measurementUnit)
        {
            var measurementUnitEntity = new measurementunit();
            try
            {
                measurementUnitEntity.InjectFrom(measurementUnit);
                _siseobDB.Entry(measurementUnitEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.measurementunits.Remove(measurementUnitEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteMeasurementUnit_DAO", ex);
                throw ex;
            }
        }
        public void UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            try
            {
                var measurementUnitEntity = _siseobDB.measurementunits.Find(measurementUnit.IdMeasurementUnit);
                if (measurementUnitEntity != null)
                {
                    measurementUnitEntity.InjectFrom(measurementUnit);
                    _siseobDB.Entry(measurementUnitEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateMeasurementUnit_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region MoneyMovementTypes
        public IList<MoneyMovementType> GetAllMoneyMovementTypes()
        {
            try
            {
                var result = new List<MoneyMovementType>();

                foreach (var item in _siseobDB.moneymovementtypes)
                {
                    var movementType = new MoneyMovementType();
                    movementType.InjectFrom(item);
                    movementType.Sign = (MovementSign)item.Sign;
                    result.Add(movementType);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllMoneyMovementTypes_DAO", ex);
                throw ex;
            }
        }
        public void InsertMoneyMovementType(MoneyMovementType moneyMovementType)
        {
            try
            {
                var movementTypeEntity = new moneymovementtype();
                movementTypeEntity.InjectFrom(moneyMovementType);
                movementTypeEntity.Sign = (sbyte)moneyMovementType.Sign;
                _siseobDB.moneymovementtypes.Add(movementTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertMoneyMovementType_DAO", ex);
                throw ex;
            }
        }
        public void DeleteMoneyMovementType(MoneyMovementType moneyMovementType)
        {
            try
            {
                var movementTypeEntity = new moneymovementtype();
                movementTypeEntity.InjectFrom(moneyMovementType);
                _siseobDB.moneymovementtypes.Remove(movementTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteMoneyMovementType_DAO", ex);
                throw ex;
            }
        }
        public void UpdateMoneyMovementType(MoneyMovementType moneyMovementType)
        {
            try
            {
                var moneyMovementTypeEntity = _siseobDB.moneymovementtypes.Find(moneyMovementType);
                if (moneyMovementTypeEntity != null)
                {
                    moneyMovementTypeEntity.InjectFrom(moneyMovementType);
                    _siseobDB.Entry(moneyMovementTypeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateMoneyMovementType_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region Tools
        public IList<Tool> GetAllTools()
        {
            try
            {
                var result = new List<Tool>();

                foreach (var item in _siseobDB.tools.Include("tooltype"))
                {
                    var tool = new Tool();
                    tool.ToolType = new ToolType();
                    tool.InjectFrom(item);
                    tool.ToolType.InjectFrom(item.tooltype);
                    result.Add(tool);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllTools_DAO", ex);
                throw ex;
            }
        }
        public void InsertTool(Tool tool)
        {
            try
            {
                var toolEntity = new tool();
                toolEntity.InjectFrom(tool);
                toolEntity.IdToolType = tool.ToolType.IdToolType;
                _siseobDB.tools.Add(toolEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertTool_DAO", ex);
                throw ex;
            }
        }
        public void DeleteTool(Tool tool)
        {
            try
            {
                var toolEntity = new tool();
                toolEntity.InjectFrom(tool);
                _siseobDB.tools.Remove(toolEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteTool_DAO", ex);
                throw ex;
            }
        }
        public void UpdateTool(Tool tool)
        {
            try
            {
                var toolEntity = _siseobDB.tools.Find(tool.IdTool);
                if (toolEntity != null)
                {
                    toolEntity.InjectFrom(tool);
                    toolEntity.IdToolType = tool.ToolType.IdToolType;
                    _siseobDB.Entry(toolEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateTool_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region ToolTypes
        public IList<ToolType> GetAllToolTypes()
        {
            try
            {
                var result = new List<ToolType>();

                foreach (var item in _siseobDB.tooltypes)
                {
                    var toolType = new ToolType();
                    toolType.InjectFrom(item);
                    result.Add(toolType);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllToolTypes_DAO", ex);
                throw ex;
            }
        }
        public void InsertToolType(ToolType toolType)
        {
            try
            {
                var toolTypeEntity = new tooltype();
                toolTypeEntity.InjectFrom(toolType);
                _siseobDB.tooltypes.Add(toolTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertToolType_DAO", ex);
                throw ex;
            }
        }
        public void DeleteToolType(ToolType toolType)
        {
            try
            {
                var toolTypeEntity = new tooltype();
                toolTypeEntity.InjectFrom(toolType);
                _siseobDB.tooltypes.Remove(toolTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteToolType_DAO", ex);
                throw ex;
            }
        }
        public void UpdateToolType(ToolType toolType)
        {
            try
            {
                var toolTypeEntity = _siseobDB.tooltypes.Find(toolType.IdToolType);
                if (toolTypeEntity != null)
                {
                    toolTypeEntity.InjectFrom(toolType);
                    _siseobDB.Entry(toolTypeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateWorkType_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region WorkTypes
        public IList<WorkType> GetAllWorkTypes()
        {
            try
            {
                var result = new List<WorkType>();

                foreach (var item in _siseobDB.worktypes)
                {
                    var workType = new WorkType();
                    workType.InjectFrom(item);
                    result.Add(workType);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateWorkType_DAO", ex);
                throw ex;
            }
        }
        public void InsertWorkType(WorkType workType)
        {
            try
            {
                var workTypeEntity = new worktype();
                workTypeEntity.InjectFrom(workType);
                _siseobDB.worktypes.Add(workTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertWorkType_DAO", ex);
                throw ex;
            }
        }
        public void DeleteWorkType(WorkType workType)
        {
            try
            {
                var workTypeEntity = new worktype();
                workTypeEntity.InjectFrom(workType);
                _siseobDB.worktypes.Remove(workTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteWorkType_DAO", ex);
                throw ex;
            }
        }
        public void UpdateWorkType(WorkType workType)
        {
            try
            {
                var workTypeEntity = _siseobDB.worktypes.Find(workType.IdWorkType);
                if (workTypeEntity != null)
                {
                    workTypeEntity.InjectFrom(workType);
                    _siseobDB.Entry(workTypeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateWorkType_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region CertificateArticles
        public IList<CertificateArticle> GetCertificateArticlesByIdCertificateArticleItem(int idCertificateArticleItem)
        {
            try
            {
                var result = new List<CertificateArticle>();
                foreach (var item in _siseobDB.certificatearticles
                    .Include("certificatearticleitem")
                    .Include("measurementunit")
                    .Include(x => x.articleprices)
                    .Where(x => x.IdCertificateArticleItem == idCertificateArticleItem).ToList())
                {
                    var certificateArticle = new CertificateArticle();
                    certificateArticle.CertificateArticleItem = new CertificateArticleItem();
                    certificateArticle.MeasurementUnit = new MeasurementUnit();
                    certificateArticle.InjectFrom(item);
                    certificateArticle.CertificateArticleItem.InjectFrom(item.certificatearticleitem);
                    certificateArticle.MeasurementUnit.InjectFrom(item.measurementunit);
                    certificateArticle.ArticlePrices = new List<ArticlePrices>();
                    foreach (var subitem in item.articleprices)
                    {
                        var article = new ArticlePrices()
                        {
                            IdArticlePrices = subitem.IdArticlePrices,
                            UnitCost = subitem.UnitCost,
                        };
                        article.CertificateArticle = new CertificateArticle();
                        article.PriceList = new PriceList();
                        article.CertificateArticle.InjectFrom(subitem.certificatearticle);
                        article.PriceList.InjectFrom(subitem.pricelist);
                        certificateArticle.ArticlePrices.Add(article);
                    }
                    result.Add(certificateArticle);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetCertificateArticlesByIdCertificateArticleItem_DAO", ex);
                throw ex;
            }
        }
        public IList<CertificateArticle> GetAllCertificateArticles()
        {
            try
            {
                var result = new List<CertificateArticle>();

                foreach (var item in _siseobDB.certificatearticles
                                    .Include("certificatearticleitem")
                                    .Include("measurementunit")
                                    .Include(x => x.articleprices).ToList())
                {
                    var certificateArticle = new CertificateArticle();
                    certificateArticle.CertificateArticleItem = new CertificateArticleItem();
                    certificateArticle.MeasurementUnit = new MeasurementUnit();
                    certificateArticle.InjectFrom(item);
                    certificateArticle.CertificateArticleItem.InjectFrom(item.certificatearticleitem);
                    certificateArticle.MeasurementUnit.InjectFrom(item.measurementunit);
                    certificateArticle.ArticlePrices = new List<ArticlePrices>();
                    foreach (var subitem in item.articleprices)
                    {
                        var article = new ArticlePrices()
                        {
                            IdArticlePrices = subitem.IdArticlePrices,
                            UnitCost = subitem.UnitCost,
                        };
                        article.PriceList = new PriceList();
                        article.PriceList.InjectFrom(subitem.pricelist);
                        certificateArticle.ArticlePrices.Add(article);
                    }
                    result.Add(certificateArticle);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllCertificateArticles_DAO", ex);
                throw;
            }
        }
        public void InsertCertificateArticle(CertificateArticle certificateArticle)
        {
            try
            {
                var certificateArticleEntity = new certificatearticle();
                certificateArticleEntity.InjectFrom(certificateArticle);
                certificateArticleEntity.IdMeasurementUnit = certificateArticle
                    .MeasurementUnit.IdMeasurementUnit;
                certificateArticleEntity.IdCertificateArticleItem = certificateArticle
                    .CertificateArticleItem.IdCertificateArticleItem;
                _siseobDB.certificatearticles.Add(certificateArticleEntity);
                foreach (var item in certificateArticle.ArticlePrices)
                {
                    var articlePricesEntity = new articleprice();
                    articlePricesEntity.InjectFrom(item);
                    articlePricesEntity.IdCertificateArticles = item.CertificateArticle.IdCertificateArticles;
                    articlePricesEntity.IdPriceList = item.PriceList.IdPriceList;
                    _siseobDB.articleprices.Add(articlePricesEntity);
                }
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticle_DAO", ex);
                throw ex;
            }
        }
        public void DeleteCertificateArticle(CertificateArticle certificateArticle)
        {
            try
            {
                var certificateArticleEntity = new certificatearticle();
                certificateArticleEntity.InjectFrom(certificateArticle);
                _siseobDB.certificatearticles.Remove(certificateArticleEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticle_DAO", ex);
                throw ex;
            }
        }
        public void UpdateCertificateArticle(CertificateArticle certificateArticle)
        {
            try
            {
                var certificateArticleEntity = _siseobDB.certificatearticles.
                    Find(certificateArticle.IdCertificateArticles);

                if (certificateArticleEntity != null)
                {
                    certificateArticleEntity.InjectFrom(certificateArticle);
                    certificateArticleEntity.IdCertificateArticleItem = certificateArticle
                        .CertificateArticleItem.IdCertificateArticleItem;
                    certificateArticleEntity.IdMeasurementUnit = certificateArticle
                        .MeasurementUnit.IdMeasurementUnit;

                    foreach (var item in certificateArticle.ArticlePrices)
                    {
                        if(item.IdArticlePrices == 0)
                        {
                            var articlePricesEntity = new articleprice();
                            articlePricesEntity.InjectFrom(item);
                            articlePricesEntity.IdCertificateArticles = item.CertificateArticle.IdCertificateArticles;
                            articlePricesEntity.IdPriceList = item.PriceList.IdPriceList;
                            _siseobDB.articleprices.Add(articlePricesEntity);
                        }
                        else
                        {
                            certificateArticleEntity.articleprices.
                                SingleOrDefault(x => x.IdArticlePrices == item.IdArticlePrices).UnitCost = item.UnitCost;
                        }
                    }

                    _siseobDB.Entry(certificateArticleEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificateArticle_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region CertificateArticleItems
        public IList<CertificateArticleItem> GetAllCertificateArticleItem()
        {
            try
            {
                var result = new List<CertificateArticleItem>();

                foreach (var item in _siseobDB.certificatearticleitems)
                {
                    var certificatearticleitem = new CertificateArticleItem();
                    certificatearticleitem.InjectFrom(item);
                    result.Add(certificatearticleitem);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllCertificateArticleItem_DAO", ex);
                throw;
            }

        }
        public void InsertCertificateArticleItem(CertificateArticleItem certificateArticleItem)
        {
            try
            {
                var certificateArticleItemEntity = new certificatearticleitem();
                certificateArticleItemEntity.InjectFrom(certificateArticleItem);
                _siseobDB.certificatearticleitems.Add(certificateArticleItemEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticleItem_DAO", ex);
                throw ex;
            }
        }
        public void DeleteCertificateArticleItem(CertificateArticleItem certificateArticleItem)
        {
            try
            {
                var certificateArticleItemEntity = new certificatearticleitem();
                certificateArticleItemEntity.InjectFrom(certificateArticleItem);
                _siseobDB.Entry(certificateArticleItemEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.certificatearticleitems.Remove(certificateArticleItemEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteCertificateArticleItem_DAO", ex);
                throw ex;
            }
        }
        public void UpdateCertificateArticleItem(CertificateArticleItem certificateArticleItem)
        {
            try
            {
                var certificateArticleItemEntity = _siseobDB.certificatearticleitems
                                                            .Find(certificateArticleItem.IdCertificateArticleItem);
                if (certificateArticleItemEntity != null)
                {
                    certificateArticleItemEntity.InjectFrom(certificateArticleItem);
                    _siseobDB.Entry(certificateArticleItemEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificateArticleItem_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region CertificateTypes
        public IList<CertificateType> GetAllCertificateTypes()
        {
            try
            {
                var result = new List<CertificateType>();

                foreach (var item in _siseobDB.certificatetypes)
                {
                    var workType = new CertificateType();
                    workType.InjectFrom(item);
                    result.Add(workType);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllCertificateTypes_DAO", ex);
                throw ex;
            }

        }
        public void InsertCertificateType(CertificateType certificateType)
        {
            try
            {
                var certificateTypeEntity = new certificatetype();
                certificateTypeEntity.InjectFrom(certificateType);
                _siseobDB.certificatetypes.Add(certificateTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateType_DAO", ex);
                throw ex;
            }
        }
        public void DeleteCertificateType(CertificateType certificateType)
        {
            try
            {
                var certificateTypeEntity = new certificatetype();
                certificateTypeEntity.InjectFrom(certificateType);
                _siseobDB.Entry(certificateTypeEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.certificatetypes.Remove(certificateTypeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteCertificateType_DAO", ex);
                throw ex;
            }
        }
        public void UpdateCertificateType(CertificateType certificateType)
        {
            try
            {
                var certificateTypeEntity = _siseobDB.certificatetypes
                                                            .Find(certificateType.IdCertificateType);
                if (certificateTypeEntity != null)
                {
                    certificateTypeEntity.InjectFrom(certificateType);
                    _siseobDB.Entry(certificateTypeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateCertificateType_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region Works
        #endregion

        #region PriceList
        public IList<PriceList> GetAllPriceLists()
        {
            try
            {
                var result = new List<PriceList>();

                foreach (var item in _siseobDB.pricelists)
                {
                    var priceList = new PriceList();
                    priceList.InjectFrom(item);
                    result.Add(priceList);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllPriceLists_DAO", ex);
                throw ex;
            }

        }
        public void InsertPriceList(PriceList priceList)
        {
            try
            {
                var priceListEntity = new pricelist();
                priceListEntity.InjectFrom(priceList);
                _siseobDB.pricelists.Add(priceListEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertPriceList_DAO", ex);
                throw ex;
            }
        }
        public void DeletePriceList(PriceList priceList)
        {
            try
            {
                var pricelistEntity = new pricelist();
                pricelistEntity.InjectFrom(priceList);
                _siseobDB.Entry(pricelistEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.pricelists.Remove(pricelistEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteCertificateType_DAO", ex);
                throw ex;
            }
        }
        public void UpdatePriceList(PriceList priceList)
        {
            try
            {
                var priceListEntity = _siseobDB.certificatetypes.Find(priceList.IdPriceList);
                if (priceListEntity != null)
                {
                    priceListEntity.InjectFrom(priceList);
                    _siseobDB.Entry(priceListEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdatePriceList_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region ArticlePrices
        public IList<ArticlePrices> GetArticlePricesByIdCertificateArticle(int IdCertificateArticle)
        {
            try
            {
                var result = new List<ArticlePrices>();
                foreach (var item in _siseobDB.articleprices
                    .Include("certificatearticle")
                    .Include("pricelist").Where(x => x.IdCertificateArticles == IdCertificateArticle))
                {
                    var articlePrices = new ArticlePrices();
                    articlePrices.CertificateArticle = new CertificateArticle();
                    articlePrices.PriceList = new PriceList();
                    articlePrices.InjectFrom(item);
                    articlePrices.CertificateArticle.InjectFrom(item.certificatearticle);
                    articlePrices.PriceList.InjectFrom(item.pricelist);
                    result.Add(articlePrices);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetArticlePricesByIdCertificateArticle_DAO", ex);
                throw ex;
            }
        }
        public IList<ArticlePrices> GetAllArticlePrices()
        {
            try
            {
                var result = new List<ArticlePrices>();

                foreach (var item in _siseobDB.articleprices
                    .Include("certificatearticle")
                    .Include("pricelist"))
                {
                    var articlePrices = new ArticlePrices();
                    articlePrices.CertificateArticle = new CertificateArticle();
                    articlePrices.PriceList = new PriceList();
                    articlePrices.InjectFrom(item);
                    articlePrices.CertificateArticle.InjectFrom(item.certificatearticle);
                    articlePrices.PriceList.InjectFrom(item.pricelist);
                    result.Add(articlePrices);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllArticlePrices_DAO", ex);
                throw;
            }
        }
        public void InsertArticlePrice(ArticlePrices articlePrices)
        {
            try
            {
                var articlePricesEntity = new articleprice();
                articlePricesEntity.InjectFrom(articlePrices);
                articlePricesEntity.IdCertificateArticles = articlePrices.CertificateArticle.IdCertificateArticles;
                articlePricesEntity.IdPriceList = articlePrices.PriceList.IdPriceList;
                _siseobDB.articleprices.Add(articlePricesEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertArticlePrice_DAO", ex);
                throw ex;
            }
        }
        public void DeleteArticlePrice(ArticlePrices articlePrices)
        {
            try
            {
                var articlePriceEntity = new articleprice();
                articlePriceEntity.InjectFrom(articlePrices);
                _siseobDB.Entry(articlePriceEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.articleprices.Remove(articlePriceEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteArticlePrice_DAO", ex);
                throw ex;
            }
        }
        public void UpdateArticlePrice(ArticlePrices articlePrices)
        {
            try
            {
                var articlePricesEntity = _siseobDB.articleprices.Find(articlePrices.IdArticlePrices);
                if (articlePricesEntity != null)
                {
                    articlePricesEntity.InjectFrom(articlePrices);
                    articlePricesEntity.IdCertificateArticles = articlePrices.CertificateArticle.IdCertificateArticles;
                    articlePricesEntity.IdPriceList = articlePrices.PriceList.IdPriceList;
                    _siseobDB.Entry(articlePricesEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateArticlePrice_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region BackupAndRestore
        public void BackupDB()
        {
            try
            {
                string constring = "server=localhost;user=root;pwd=root;database=siseob;";

                // Important Additional Connection Options
                constring += "charset=utf8;convertzerodatetime=true;";

                string file = "C:\\backup.sql";

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("BackupDB", ex);
                throw;
            }
        }

        #endregion
    }

}
