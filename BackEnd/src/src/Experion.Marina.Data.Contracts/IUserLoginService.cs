
using Experion.Marina.Data.Contracts.Entities;

namespace Experion.Marina.Data.Contracts
{
    public interface IUserLoginService
    {
        IUserLogin LoginUser(string user);
    }
}
