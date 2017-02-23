using Autofac;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System.Linq;

namespace Experion.Marina.Data.Services.Services
{
    public class UserLoginService : DataService<MarinaContext>, IUserLoginService
    {
        public UserLoginService(IComponentContext iocContext, IRepositoryContext context) : base(iocContext, context)
        {
        }

        private IRepository<UserLogin, long> UserRepository => DataContext.GetRepository<UserLogin, long>();

        public IUserLogin LoginUser(string user)
        {
            var param = new Specification<UserLogin>(x => (x.UserName == user));
            var User = UserRepository.GetBySpecification(param).FirstOrDefault();            
            return User;
        }
    }
}
