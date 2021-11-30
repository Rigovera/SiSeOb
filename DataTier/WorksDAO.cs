using CoreTier.Works;
using Omu.ValueInjecter;
using DataTier.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTier.SystemAdministration;
using CoreTier.Assignments;

namespace DataTier
{
    public class WorksDAO : DataRepository, IWorksDAO
    {
        #region Clients
        public IList<Client> GetAllClients()
        {
            try
            {
                var result = new List<Client>();

                foreach (var item in _siseobDB.clients)
                {
                    var client = new Client();
                    client.InjectFrom(item);
                    result.Add(client);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllClients_DAO", ex);
                throw;
            }
        }
        public void InsertClient(Client client)
        {
            try
            {
                var clientEntity = new client();
                clientEntity.InjectFrom(client);
                _siseobDB.clients.Add(clientEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertClient_DAO", ex);
                throw ex;
            }
        }
        public void DeleteClient(Client client)
        {
            try
            {
                var clientEntity = new client();
                clientEntity.InjectFrom(client);
                _siseobDB.clients.Remove(clientEntity);
                _siseobDB.Entry(clientEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteClient_DAO", ex);
                throw ex;
            }
        }
        public void UpdateClient(Client client)
        {
            try
            {
                var clientEntity = _siseobDB.clients.Find(client.IdClient);
                if (clientEntity != null)
                {
                    clientEntity.InjectFrom(client);
                    _siseobDB.Entry(clientEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateClient_DAO", ex);
            }
        }
        #endregion

        #region Works
        public IList<Work> GetAllWorks()
        {
            try
            {
                var result = new List<Work>();
                foreach (var item in _siseobDB.works.Include("worktype").Include("location").Include("client"))
                {
                    var work = new Work();
                    work.Location = new Location();
                    work.Client = new Client();
                    work.WorkType = new WorkType();
                    work.InjectFrom(item);
                    work.Location.InjectFrom(item.location);
                    work.Client.InjectFrom(item.client);
                    work.WorkType.InjectFrom(item.worktype);
                    result.Add(work);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllWorks_DAO", ex);
                throw;
            }           
        }
        public void InsertWork(Work work)
        {
            try
            {
                var workEntity = new work();
                workEntity.InjectFrom(work);
                workEntity.IdWorkType = work.WorkType.IdWorkType;
                workEntity.IdLocation = work.Location.IdLocation;
                workEntity.IdClient = work.Client.IdClient;
                _siseobDB.works.Add(workEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertWork_DAO", ex);
                throw ex;
            }
        }
        public void DeleteWork(Work work)
        {
            try
            {
                var workEntity = new work();
                workEntity.InjectFrom(work);
                _siseobDB.Entry(workEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.works.Remove(workEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteWork_DAO", ex);
                throw ex;
            }
        }
        public void UpdateWork(Work work)
        {
            try
            {
                var workEntity = _siseobDB.works.Find(work.IdWork);
                if (workEntity != null)
                {
                    workEntity.InjectFrom(work);
                    workEntity.IdWorkType = work.WorkType.IdWorkType;
                    workEntity.IdLocation = work.Location.IdLocation;
                    workEntity.IdClient = work.Client.IdClient;
                    _siseobDB.Entry(workEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateWork_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region Assignment
        public IList<AssignedEmployee> GetAllAssignedEmployeesFromOneWork(Work work)
        {
            try
            {
                var result = new List<AssignedEmployee>();

                foreach (var item in _siseobDB.assignedemployees.Include("employee").Include("employee.employeetype").Include("work")
                                                .Where(x => x.IdWork == work.IdWork))
                {
                    var assignedEmployee = new AssignedEmployee();
                    assignedEmployee.Work = new Work();
                    assignedEmployee.Employee = new Employee();
                    assignedEmployee.Employee.EmployeeType = new EmployeeType();
                    assignedEmployee.InjectFrom(item);
                    if (!item.Assigned)
                        assignedEmployee.AssignmentState = AssignmentState.Unassigned;
                    else
                        assignedEmployee.AssignmentState = AssignmentState.Assigned;
                    assignedEmployee.Work.InjectFrom(item.work);
                    assignedEmployee.Employee.InjectFrom(item.employee);
                    assignedEmployee.Employee.EmployeeType.InjectFrom(item.employee.employeetype);
                    result.Add(assignedEmployee);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllAssignedEmployeesFromOneWork_DAO", ex);
                throw;
            }
        }
        public void InsertAssignedEmployee(AssignedEmployee assignedEmployee)
        {
            try
            {
                var assignedEmployeeEntity = new assignedemployee();
                assignedEmployeeEntity.InjectFrom(assignedEmployee);
                assignedEmployeeEntity.IdWork = assignedEmployee.Work.IdWork;
                assignedEmployeeEntity.IdEmployee = assignedEmployee.Employee.IdEmployee;
                assignedEmployeeEntity.Assigned = true;
                _siseobDB.assignedemployees.Add(assignedEmployeeEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertAssignedEmployee_DAO", ex);
                throw ex;
            }
        }
        public void UpdateAssignedEmployee(AssignedEmployee assignedEmployee)
        {
            try
            {
                var assignedEmployeeEntity = _siseobDB.assignedemployees.Find(assignedEmployee.IdAssignedEmployee);
                if (assignedEmployeeEntity != null)
                {
                    assignedEmployeeEntity.InjectFrom(assignedEmployee);
                    assignedEmployeeEntity.DateOfDeallocate = assignedEmployee.DateOfDeallocate;
                    if (assignedEmployee.AssignmentState == AssignmentState.Assigned)
                        assignedEmployeeEntity.Assigned = true;
                    else
                        assignedEmployeeEntity.Assigned = false;
                    _siseobDB.Entry(assignedEmployeeEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateAssignedEmployee_DAO", ex);
                throw ex;
            }
        }

        public IList<AssignedTool> GetAllAssignedToolFromOneWork(Work work)
        {
            try
            {
                var result = new List<AssignedTool>();

                foreach (var item in _siseobDB.assignedtools.Include("tool").Include("tool.tooltype").Include("work")
                                                .Where(x => x.IdWork == work.IdWork))
                {
                    var assignedTool = new AssignedTool();
                    assignedTool.Work = new Work();
                    assignedTool.Tool = new Tool();
                    assignedTool.Tool.ToolType = new ToolType();
                    assignedTool.InjectFrom(item);
                    if (!item.Assigned)
                        assignedTool.AssignmentState = AssignmentState.Unassigned;
                    else
                        assignedTool.AssignmentState = AssignmentState.Assigned;
                    assignedTool.Work.InjectFrom(item.work);
                    assignedTool.Tool.InjectFrom(item.tool);
                    assignedTool.Tool.ToolType.InjectFrom(item.tool.tooltype);
                    result.Add(assignedTool);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllAssignedToolFromOneWork_DAO", ex);
                throw;
            }            
        }
        public void InsertAssignedTool(AssignedTool assignedTool)
        {
            try
            {
                var assignedToolEntity = new assignedtool();
                assignedToolEntity.InjectFrom(assignedTool);
                assignedToolEntity.IdWork = assignedTool.Work.IdWork;
                assignedToolEntity.IdTool = assignedTool.Tool.IdTool;
                assignedToolEntity.Assigned = true;
                _siseobDB.assignedtools.Add(assignedToolEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertAssignedTool_DAO", ex);
                throw ex;
            }
        }
        public void UpdateAssignedTool(AssignedTool assignedTool)
        {
            try
            {
                var assignedToolEntity = _siseobDB.assignedtools.Find(assignedTool.IdAssignedTool);
                if (assignedToolEntity != null)
                {
                    assignedToolEntity.InjectFrom(assignedTool);
                    assignedToolEntity.DateOfDeallocate = assignedTool.DateOfDeallocate;
                    if (assignedTool.AssignmentState == AssignmentState.Assigned)
                        assignedToolEntity.Assigned = true;
                    else
                        assignedToolEntity.Assigned = false;
                    _siseobDB.Entry(assignedTool).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateAssignedTool_DAO", ex);
                throw ex;
            }
        }
        #endregion
    }
}
