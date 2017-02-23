
using Experion.Marina.Data.Contracts.Entities;
using System.Collections.Generic;

namespace Experion.Marina.Data.Contracts
{
    public interface ISearchEmployeeService
    {
        IEnumerable<IEmployee> Search(string searchby, string filterby, string query);
    }
}
