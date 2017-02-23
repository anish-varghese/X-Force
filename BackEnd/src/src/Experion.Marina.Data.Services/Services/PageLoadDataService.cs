using Autofac;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System;
using System.Collections.Generic;

namespace Experion.Marina.Data.Services.Services
{
    public class PageLoadDataService : DataService<MarinaContext>, IPageLoadDataService
    {
        public PageLoadDataService(IComponentContext iocContext, IRepositoryContext context) : base(iocContext, context)
        {
        }

        private IRepository<Attributes, long> AttributeRepository => DataContext.GetRepository<Attributes, long>();
        private IRepository<Band, long> BandRepository => DataContext.GetRepository<Band, long>();
        private IRepository<Designation, long> DesignationRepository => DataContext.GetRepository<Designation, long>();
        private IRepository<FilterOperator, long> FilterOperatorRepository => DataContext.GetRepository<FilterOperator, long>();

        public IEnumerable<IAttributes> GetAttributes()
        {
            IEnumerable<IAttributes> entity = AttributeRepository.GetAll();
            return entity;
        }

        public IEnumerable<IBand> GetBand()
        {
            IEnumerable<IBand> band = BandRepository.GetAll();
            return band;
        }

        public IEnumerable<IDesignation> GetDesignation()
        {
            IEnumerable<IDesignation> designation = DesignationRepository.GetAll();
            return designation;
        }

        public IEnumerable<IFilterOperators> GetFilterOperators(long AttributeId=1)
        {
            var param = new Specification<FilterOperator>(x => (x.AttributesId == AttributeId));
            var operators = FilterOperatorRepository.GetBySpecification(param);
            return operators;
        }
    }
}
