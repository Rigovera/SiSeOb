using CoreTier.Assignments;
using CoreTier.Works;

using System.Collections.Generic;

namespace DataTier
{
    public interface IWorksDAO
    {
        IList<Client> GetAllClients();
        void InsertClient(Client client);
        void DeleteClient(Client client);
        void UpdateClient(Client client);

        IList<Work> GetAllWorks();
        void InsertWork(Work work);
        void DeleteWork(Work work);
        void UpdateWork(Work work);

        IList<AssignedEmployee> GetAllAssignedEmployeesFromOneWork(Work work);
        void InsertAssignedEmployee(AssignedEmployee assignedEmployee);
        void UpdateAssignedEmployee(AssignedEmployee assignedEmployee);

        IList<AssignedTool> GetAllAssignedToolFromOneWork(Work work);
        void InsertAssignedTool(AssignedTool assignedTool);
        void UpdateAssignedTool(AssignedTool assignedTool);
    }
}
