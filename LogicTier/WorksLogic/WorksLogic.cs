using CoreTier.Assignments;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.WorksLogic
{
    public class WorksLogic : IWorksLogic
    {
        private IWorksDAO _worksDAO;
        public WorksLogic()
        {
            _worksDAO = new WorksDAO();
        }
        #region Clients
        public IList<Client> GetAllClients()
        {
            try
            {
                var result = _worksDAO.GetAllClients();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllClients_Logic", ex);
                throw ex;
            }            
        }
        public void InsertClient(Client client)
        {
            try
            {
                _worksDAO.InsertClient(client);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertClient_Logic", ex);
                throw;
            }
            
        }
        public void DeleteClient(Client client)
        {
            try
            {
                _worksDAO.DeleteClient(client);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteClient_Logic", ex);
                throw ex;
            }            
        }
        public void UpdateClient(Client client)
        {
            try
            {
                _worksDAO.UpdateClient(client);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateClient_Logic", ex);
                throw ex;
            }            
        }
        #endregion

        #region Works
        public IList<Work> GetAllWorks()
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorks_Logic", ex);
                throw ex;
            }           
        }
        public void InsertWork(Work work)
        {
            try
            {
                _worksDAO.InsertWork(work);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertWork_Logic", ex);
                throw ex;
            }
           
        }
        public void DeleteWork(Work work)
        {
            try
            {
                _worksDAO.DeleteWork(work);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteWork_Logic", ex);
                throw ex;
            }            
        }
        public void UpdateWork(Work work)
        {
            try
            {
                _worksDAO.UpdateWork(work);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateWork_Logic", ex);
                throw ex;
            }            
        }

        public IList<Work> GetAllWorksWhoseNameContains(string filter)
        {
            try
            {
                if(filter != null)
                {
                    var result = _worksDAO.GetAllWorks();
                    result = result.Where(x => x.Name.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksWhoseNameContains_Logic", ex);
                throw ex;
            }            
        }
        public IList<Work> GetAllWorksByWorkType(int idWorkType)
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                result = result.Where(x => x.WorkType.IdWorkType == idWorkType).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByWorkType_Logic", ex);
                throw ex;
            }            
        }
        public IList<Work> GetAllWorksByLocation(int idLocation)
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                result = result.Where(x => x.Location.IdLocation == idLocation).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByLocation_Logic", ex);
                throw ex;
            }            
        }
        public IList<Work> GetAllWorksByClient(int idClient)
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                result = result.Where(x => x.Client.IdClient == idClient).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByClient_Logic", ex);
                throw ex;
            }            
        }
        public IList<Work> GetAllWorksByStartDate(DateTime startDate)
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                result = result.Where(x => x.StartDate.Date >= startDate.Date).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByStartDate_Logic", ex);
                throw ex;
            }            
        }
        public IList<Work> GetAllWorksByFinishDate(DateTime finishDate)
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                result = result.Where(x => x.FinishDate.HasValue && x.FinishDate.Value <= finishDate.Date).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByFinishDate_Logic", ex);
                throw ex;
            }
            
        }
        public IList<Work> GetAllWorksByPossibleEndDate(DateTime possibleEndDate)
        {
            try
            {
                var result = _worksDAO.GetAllWorks();
                result = result.Where(x => x.PossibleEndDate.Date <= possibleEndDate.Date).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorksByPossibleEndDate_Logic", ex);
                throw ex;
            }            
        }
        #endregion

        #region Assignment
        public IList<AssignedEmployee> GetAllAssignedEmployeesFromOneWork(Work work)
        {
            try
            {
                var result = _worksDAO.GetAllAssignedEmployeesFromOneWork(work);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllAssignedEmployeesFromOneWork_Logic", ex);
                throw ex;
            }            
        }
        public void InsertAssignedEmployee(AssignedEmployee assignedEmployee)
        {
            try
            {
                _worksDAO.InsertAssignedEmployee(assignedEmployee);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertAssignedEmployee_Logic", ex);
                throw ex;
            }            
        }
        public void UpdateAssignedEmployee(AssignedEmployee assignedEmployee)
        {
            try
            {
                _worksDAO.UpdateAssignedEmployee(assignedEmployee);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateAssignedEmployee_Logic", ex);
                throw ex;
            }            
        }

        public IList<AssignedTool> GetAllAssignedToolFromOneWork(Work work)
        {
            try
            {
                var result = _worksDAO.GetAllAssignedToolFromOneWork(work);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllAssignedToolFromOneWork_Logic", ex);
                throw ex;
            }            
        }
        public void InsertAssignedTool(AssignedTool assignedTool)
        {
            try
            {
                _worksDAO.InsertAssignedTool(assignedTool);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertAssignedTool_Logic", ex);
                throw ex;
            }
            
        }
        public void UpdateAssignedTool(AssignedTool assignedTool)
        {
            try
            {
                _worksDAO.UpdateAssignedTool(assignedTool);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateAssignedTool_Logic", ex);
                throw ex;
            }            
        }       

        #endregion
    }
}
