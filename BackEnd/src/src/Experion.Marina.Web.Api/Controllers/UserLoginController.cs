using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class UserLoginController : ApiController
    {
        private readonly IComponentContext _iocContext;

        public UserLoginController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        [HttpPost]
        [Route("api/user/login")]
        public UserDto Login(UserLoginDto user)
        {
            var userService = _iocContext.Resolve<ILoginService>();
            var logedUser=userService.Login(user);
            return logedUser;
        }
    }
}
