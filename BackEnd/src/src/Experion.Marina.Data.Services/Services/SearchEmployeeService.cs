using Autofac;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System.Collections.Generic;
using System;

namespace Experion.Marina.Data.Services.Services
{
    public class SearchEmployeeService : DataService<MarinaContext>, ISearchEmployeeService
    {
        public SearchEmployeeService(IComponentContext iocContext, IRepositoryContext context) : base(iocContext, context)
        {
        }

        private IRepository<Employee, long> EmployeeRepository => DataContext.GetRepository<Employee, long>();

        public IEnumerable<IEmployee> Search(string searchby, string filterby, string query)
        {
            throw new NotImplementedException();
        }
    }
}
