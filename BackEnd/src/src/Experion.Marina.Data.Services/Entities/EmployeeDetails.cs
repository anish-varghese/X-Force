using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
    public class EmployeeDetails : IEmployeeDetails
    {
        public IEmployee Employee { get; set; }

        public IBand EmployeeBand { get; set; }

        public IDesignation EmployeeDesignation { get; set; }
    }
}
