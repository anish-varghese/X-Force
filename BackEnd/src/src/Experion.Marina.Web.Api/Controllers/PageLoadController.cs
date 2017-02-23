using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class PageLoadController : ApiController
    {
        private readonly IComponentContext _iocContext;

        public PageLoadController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }
        [HttpGet]
        [Route("api/pageload")]
        public ResponseDto<PageLoadDto> GetPageLoadData()
        {
            var pageLoadService = _iocContext.Resolve<IPageLoad>();
            var responseDto = new ResponseDto<PageLoadDto>();
            PageLoadDto data = new PageLoadDto();

            try
            {
                data.Attributes = pageLoadService.GetAttributes();
                data.Bands = pageLoadService.GetBand();
                data.Designation = pageLoadService.GetDesignation();
                data.FilterOperators = pageLoadService.GetFilterOperators(1);
                responseDto.Data = data ?? null;
                responseDto.Messages = null;
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;
        }

        [HttpGet]
        [Route("api/addEmployee")]
        public ResponseDto<AddEmployeeDto> AddEmployeeData()
        {
            var pageLoadService = _iocContext.Resolve<IPageLoad>();
            var responseDto = new ResponseDto<AddEmployeeDto>();
            AddEmployeeDto data = new AddEmployeeDto();
            data.Bands = pageLoadService.GetBand();
            data.Designation = pageLoadService.GetDesignation();
            responseDto.Data = data ?? null;
            return responseDto;
        }

        [HttpGet]
        [Route("api/filter/{id}")]
        public ResponseDto<PageLoadDto> GetFilterOperator(long id)
        {
            var pageLoadService = _iocContext.Resolve<IPageLoad>();
            var responseDto = new ResponseDto<PageLoadDto>();
            PageLoadDto data = new PageLoadDto();
            data.FilterOperators = pageLoadService.GetFilterOperators(id);
            data.Bands = pageLoadService.GetBand();
            data.Designation = pageLoadService.GetDesignation();
            try
            {
                responseDto.Data = data ?? null;
                responseDto.Messages = null;                
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;

        }
    }
    }
