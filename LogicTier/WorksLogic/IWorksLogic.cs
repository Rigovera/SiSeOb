using CoreTier.Assignments;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.WorksLogic
{
    public interface IWorksLogic
    {
        IList<Client> GetAllClients();
        void InsertClient(Client client);
        void DeleteClient(Client client);
        void UpdateClient(Client client);

        IList<Work> GetAllWorks();
        void InsertWork(Work work);
        void DeleteWork(Work work);
        void UpdateWork(Work work);
        IList<Work> GetAllWorksWhoseNameContains(string filter);
        IList<Work> GetAllWorksByWorkType(int idWorkType);
        IList<Work> GetAllWorksByLocation(int idLocation);
        IList<Work> GetAllWorksByClient(int idClient);
        IList<Work> GetAllWorksByStartDate(DateTime startDate);
        IList<Work> GetAllWorksByFinishDate(DateTime finishDate);
        IList<Work> GetAllWorksByPossibleEndDate(DateTime possibleEndDate);

        IList<AssignedEmployee> GetAllAssignedEmployeesFromOneWork(Work work);
        void InsertAssignedEmployee(AssignedEmployee assignedEmployee);
        void UpdateAssignedEmployee(AssignedEmployee assignedEmployee);

        IList<AssignedTool> GetAllAssignedToolFromOneWork(Work work);
        void InsertAssignedTool(AssignedTool assignedTool);
        void UpdateAssignedTool(AssignedTool assignedTool);

    }
}
