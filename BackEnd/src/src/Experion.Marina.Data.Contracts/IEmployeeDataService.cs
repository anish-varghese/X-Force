using Experion.Marina.Data.Contracts.Entities;
using System.Collections.Generic;

namespace Experion.Marina.Data.Contracts
{
    public interface IEmployeeDataService
    {
        IEmployee GetEmployee(long id);
        bool SaveNewEmployee(IEmployee employee);
        void DeleteEmployee(long id);
        void EditEmployee(IEmployee editEmployee);
        IEnumerable<IEmployeeDetails> GetAllEmployees();
        IEnumerable<IEmployeeDetails> GetFilteredEmployee(long searchBy, long filterBy, string query, string toDate);     

    }
}
