using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class EmployeeController : ApiController
    {

        private readonly IComponentContext _iocContext;

        public EmployeeController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        [HttpGet]
        [Route("api/employee/get/{id}")]
        public ResponseDto<EmployeeDto> GetEmployee(long id)
        {
            var employeeService = _iocContext.Resolve<IEmployeeService>();
            var responseDto = new ResponseDto<EmployeeDto>();

            try
            {
                var Employee = employeeService.GetEmployee(id);
                responseDto.Data = Employee ?? null;
                responseDto.Messages = null;
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;
        }

        [HttpPost]
        [Route("api/employee/save")]
        public IHttpActionResult SaveEmployee(EmployeeDto Employee)
        {
            var EmployeeService = _iocContext.Resolve<IEmployeeService>();
            var status=EmployeeService.SaveEmployee(Employee);
            return Ok(status);
        }

        [HttpPost]
        [Route("api/employee/delete/{id}")]
        public IHttpActionResult DeleteEmployee(long id)
        {
            var EmployeeService = _iocContext.Resolve<IEmployeeService>();
            EmployeeService.DeleteEmployee(id);
            return Ok();
        }


        [HttpPost]
        [Route("api/employee/edit")]
        public IHttpActionResult EditEmployee(EmployeeDto employee)
        {
            var EmployeeService = _iocContext.Resolve<IEmployeeService>();
            EmployeeService.EditEmployee(employee);
            return Ok();
        }

        [HttpGet]
        [Route("api/employee/all")]
        public ResponseDto<List<EmployeeDto>> GetAllEmployee()
        {
            var employeeService = _iocContext.Resolve<IEmployeeService>();
            var responseDto = new ResponseDto<List<EmployeeDto>>();

            try
            {
                List<EmployeeDto> Employee = employeeService.GetAllEmployees();
                responseDto.Data = Employee ?? null;
                responseDto.Messages = null;
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;
        }

        [HttpPost]
        [Route("api/employee/filter")]
        public ResponseDto<List<EmployeeDto>> GetFilteredEmployee(SearchParametersDto query)
        {
            var EmployeeService = _iocContext.Resolve<IEmployeeService>();
            var responseDto = new ResponseDto<List<EmployeeDto>>();

            try
            {
                List<EmployeeDto> Employee = EmployeeService.GetFilteredEmployee(query);
                responseDto.Data = Employee ?? null;
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
