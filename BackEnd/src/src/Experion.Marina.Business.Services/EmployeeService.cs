using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Dto;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Experion.Marina.Business.Services
{
    public class EmployeeService : BusinessService, IEmployeeService
    {
        private readonly IComponentContext _iocContext;       

        public EmployeeService(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        public EmployeeDto GetEmployee(long id)
        {
            var employeeDataService = _iocContext.Resolve<IEmployeeDataService>();            
            var employeeEntity = employeeDataService.GetEmployee(id);

            return new EmployeeDto
            {
                Id = employeeEntity.Id,
                Name = employeeEntity.Name,
                DateOfJoin = employeeEntity.DateOfJoin,
                DesignationId = employeeEntity.DesignationId,
                Number = employeeEntity.Number,
                BandId = employeeEntity.BandId                
            };
        }

        public bool SaveEmployee(EmployeeDto newEmployee)
        {
            var employeeDataService = _iocContext.Resolve<IEmployeeDataService>();
            IEmployee employee = _iocContext.Resolve<IEmployee>();

            employee.Name = newEmployee.Name;
            employee.DateOfJoin = newEmployee.DateOfJoin;
            employee.Number = newEmployee.Number;
            employee.DesignationId = newEmployee.DesignationId;
            employee.BandId = newEmployee.BandId;
            var status = employeeDataService.SaveNewEmployee(employee);
            if(!status)
            {
                return false;
            }
            else { return true; }

        }

        public void DeleteEmployee(long id)
        {
            var employeeDataService = _iocContext.Resolve<IEmployeeDataService>();
            employeeDataService.DeleteEmployee(id);
        }

        public void EditEmployee(EmployeeDto editemployee)
        {
            var employeeDataService = _iocContext.Resolve<IEmployeeDataService>();
            IEmployee employee = _iocContext.Resolve<IEmployee>();

            employee.Id = editemployee.Id;
            employee.Name = editemployee.Name;
            employee.DateOfJoin = editemployee.DateOfJoin;
            employee.Number = editemployee.Number;
            employee.DesignationId = editemployee.DesignationId;
            employee.BandId = editemployee.BandId;

            employeeDataService.EditEmployee(employee);
        }


        public List<EmployeeDto> GetAllEmployees()
        {
            var employeeDataService = _iocContext.Resolve<IEmployeeDataService>();
            var employees = employeeDataService.GetAllEmployees();
            //List<EmployeeDto> employeeList = new List<EmployeeDto>();

            var employeeList = employees.Select(e => new EmployeeDto
            {
                Id = e.Employee.Id,
                BandId = e.Employee.BandId,
                BandName = e.EmployeeBand.Name,
                Name = e.Employee.Name,
                DateOfJoin = e.Employee.DateOfJoin,
                DesignationId = e.Employee.DesignationId,
                DesignationName = e.EmployeeDesignation.Name,
                Number = e.Employee.Number
            }).ToList();

            return employeeList;
        }

        public List<EmployeeDto> GetFilteredEmployee(SearchParametersDto query)
        {
            var employeeDataService = _iocContext.Resolve<IEmployeeDataService>();
            var employees = employeeDataService.GetFilteredEmployee(query.SearchBy, query.FilterBy, query.Query, query.toDate);
            var employeeList = employees.Select(e => new EmployeeDto
            {
                Id = e.Employee.Id,
                BandId = e.Employee.BandId,
                BandName = e.EmployeeBand.Name,
                Name = e.Employee.Name,
                DateOfJoin = e.Employee.DateOfJoin,
                DesignationId = e.Employee.DesignationId,
                DesignationName = e.EmployeeDesignation.Name,
                Number = e.Employee.Number
            }).ToList();
            return employeeList;
        }
    }
}
