using Autofac;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Experion.Marina.Data.Services.Services
{
    public class EmployeeDataService : DataService<MarinaContext>, IEmployeeDataService
    {
        public EmployeeDataService(IComponentContext iocContext, IRepositoryContext context) : base(iocContext, context)
        {
        }

        private IRepository<Employee, long> EmployeeRepository => DataContext.GetRepository<Employee, long>();

        public IEmployee GetEmployee(long id)
        {
            var entity = EmployeeRepository.GetById(id);
            return entity;
        }

        public bool SaveNewEmployee(IEmployee newEmployee)
        {
            var param = new Specification<Employee>(x => (x.Number == newEmployee.Number));
            var employeeTest = EmployeeRepository.GetBySpecification(param);
            if (employeeTest.Count == 0)
            {
                var employee = new Employee
                {
                    Name = newEmployee.Name,
                    Number = newEmployee.Number,
                    DateOfJoin = newEmployee.DateOfJoin,
                    DesignationId = newEmployee.DesignationId,
                    BandId = newEmployee.BandId
                };
                EmployeeRepository.Add(employee);
                Save();
                return true;
            }
            else return false;

        }

        public void DeleteEmployee(long id)
        {
            var entity = EmployeeRepository.GetById(id);
            EmployeeRepository.Delete(entity);
            Save();
        }

        public void EditEmployee(IEmployee employee)
        {
            var entity = EmployeeRepository.GetById(employee.Id);
            entity.Name = entity.Name;
            entity.Number = entity.Number;
            entity.DesignationId = entity.DesignationId;
            entity.DateOfJoin = entity.DateOfJoin;
            entity.BandId = entity.BandId;
            EmployeeRepository.Update(entity);
            Save();
        }

        public IEnumerable<IEmployeeDetails> GetAllEmployees()
        {
            var employees = EmployeeRepository.GetAll();

            var employeeDetails = employees.Select(e => new EmployeeDetails
            {
                Employee = e,
                EmployeeBand = e.Band,
                EmployeeDesignation = e.Designation
            });
            
            return employeeDetails;
        }

        public IEnumerable<IEmployeeDetails> GetFilteredEmployee(long searchBy, long filterBy, string query, string toDate)
        {
            var employees = GetFilteredEmployeeDetails( searchBy, filterBy, query, toDate);

            var employeeDetails = employees.Select(e => new EmployeeDetails
            {
                Employee = e,
                EmployeeBand = e.Band,
                EmployeeDesignation = e.Designation
            });
            return employeeDetails;

        }


         private IEnumerable<Employee> GetFilteredEmployeeDetails(long searchBy, long filterBy, string query, string toDate)
        {
            //List<IEmployee> employee = new List<IEmployee>(); 
            var param = new Specification<Employee>(x => (x.Number == 0));
            var employee = EmployeeRepository.GetBySpecification(param);


            if (searchBy == 1)
            {
                var number = Convert.ToInt64(query);
                switch (filterBy)
                {
                    case 1:
                        
                        param = new Specification<Employee>(x => (x.Number == number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 2:
                        param = new Specification<Employee>(x => (x.Number != number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 3:
                        param = new Specification<Employee>(x => (x.Number < number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 4:
                        param = new Specification<Employee>(x => (x.Number > number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 5:
                        param = new Specification<Employee>(x => (x.Number <= number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 6:
                        param = new Specification<Employee>(x => (x.Number >= number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                }
                return employee;
            }
            else if (searchBy == 2)
            {
                switch (filterBy)
                {
                    case 7:
                        param = new Specification<Employee>(x => (x.Name == query));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 8:
                        param = new Specification<Employee>(x => (x.Name != query));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 9:
                        param = new Specification<Employee>(x => (x.Name.Contains(query)));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                }
                return employee;
            }
            else if (searchBy == 3)
            {
                var date = Convert.ToDateTime(query);
                switch (filterBy)
                {
                    case 10:
                        var todate = Convert.ToDateTime(toDate);
                        param = new Specification<Employee>(x => ((x.DateOfJoin > date)&&(x.DateOfJoin<todate)));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 11:
                        param = new Specification<Employee>(x => (x.DateOfJoin == date));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 12:
                        param = new Specification<Employee>(x => (x.DateOfJoin != date));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 13:
                        param = new Specification<Employee>(x => (x.DateOfJoin < date));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 14:
                        param = new Specification<Employee>(x => (x.DateOfJoin > date));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 15:
                        param = new Specification<Employee>(x => (x.DateOfJoin <= date));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 16:
                        param = new Specification<Employee>(x => (x.DateOfJoin >= date));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                }
                return employee;
            }
            else if (searchBy == 4)
            {
                var number = Convert.ToInt64(query);
                switch (filterBy)
                {
                    case 17:
                        param = new Specification<Employee>(x => (x.DesignationId == number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 18:
                        param = new Specification<Employee>(x => (x.DesignationId != number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                }
                return employee;
            }
            else if (searchBy == 5)
            {
                var number = Convert.ToInt64(query);
                switch (filterBy)
                {
                    case 20:
                        param = new Specification<Employee>(x => (x.BandId == number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                    case 21:
                        param = new Specification<Employee>(x => (x.BandId != number));
                        employee = EmployeeRepository.GetBySpecification(param);
                        break;
                }
                return employee;
            }
            return employee;
        }
    }
}
