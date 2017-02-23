using System;
using System.Collections.Generic;
using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Dto;
using Experion.Marina.Data.Contracts;

namespace Experion.Marina.Business.Services
{
    public class PageLoad : BusinessService, IPageLoad
    {
        private readonly IComponentContext _iocContext;

        public PageLoad(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        public List<AttributesDto> GetAttributes()
        {
            var pageLoadContext = _iocContext.Resolve<IPageLoadDataService>();
            var attributes = pageLoadContext.GetAttributes();
            List<AttributesDto> Attributes = new List<AttributesDto>();
            foreach (var attribute in attributes)
            {
                Attributes.Add( new AttributesDto
                {
                    Id = attribute.Id,
                    Name = attribute.Name
                });
            }
            return Attributes;
        }

        public List<BandDto> GetBand()
        {
            var pageLoadContext = _iocContext.Resolve<IPageLoadDataService>();
            var bands = pageLoadContext.GetBand();
            List<BandDto> Bands = new List<BandDto>();
            foreach (var band in bands)
            {
                Bands.Add(new BandDto
                {
                    Id = band.Id,
                    Name = band.Name
                });
            }
            return Bands;
        }

        public List<DesignationDto> GetDesignation()
        {
            var pageLoadContext = _iocContext.Resolve<IPageLoadDataService>();
            var designations = pageLoadContext.GetDesignation();
            List<DesignationDto> Designation = new List<DesignationDto>();
            foreach (var designation in designations)
            {
                Designation.Add(new DesignationDto
                {
                    Id = designation.Id,
                    Name = designation.Name
                });
            }
            return Designation;
        }

        public List<FilterOperatorDto> GetFilterOperators(long AttributeId)
        {
            var pageLoadContext = _iocContext.Resolve<IPageLoadDataService>();
            var operators = pageLoadContext.GetFilterOperators(AttributeId);
            List<FilterOperatorDto> Operators = new List<FilterOperatorDto>();
            foreach (var data in operators)
            {
                Operators.Add(new FilterOperatorDto
                {
                    Id = data.Id,
                    Operator = data.Operator
                });
            }
            return Operators;
        }
    }
}
