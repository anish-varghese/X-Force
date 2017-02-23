using Experion.Marina.Dto;
using System.Collections.Generic; 

namespace Experion.Marina.Business.Services.Contracts
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployee(long id);
        bool SaveEmployee(EmployeeDto Employee);
        void DeleteEmployee(long id);
        void EditEmployee(EmployeeDto editEmployee);
        List<EmployeeDto> GetAllEmployees();
        List<EmployeeDto> GetFilteredEmployee(SearchParametersDto query);
    }
}
