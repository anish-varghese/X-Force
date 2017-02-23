using System;
using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Dto;

namespace Experion.Marina.Business.Services
{
    public class LoginService : BusinessService, ILoginService
    {
        private readonly IComponentContext _iocContext;

        public LoginService(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        UserDto ILoginService.Login(UserLoginDto user)
        {
            var loginDataService = _iocContext.Resolve<IUserLoginService>();
            var userDetails = loginDataService.LoginUser(user.UserName);
            if (userDetails != null)
            {
                if (userDetails.Password == user.Password)
                {
                    UserDto logedUser = new UserDto
                    {
                        Id = userDetails.Id,
                        Name = userDetails.UserName,
                        Status = true
                    };
                    return logedUser;
                }
                return new UserDto { Name = user.UserName, Status = false };
            }
            else
            {
                return new UserDto { Status = false };
            }
        }      
    }
}
