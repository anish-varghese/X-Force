using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IEmployeeDetails
    {
        IEmployee Employee { get; set; }
        IBand EmployeeBand { get; set; }
        IDesignation EmployeeDesignation { get; set; }
    }
}
