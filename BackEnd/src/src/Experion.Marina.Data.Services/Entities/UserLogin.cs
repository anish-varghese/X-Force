
using Experion.Marina.Data.Contracts.Entities;

namespace Experion.Marina.Data.Services.Entities
{
    public class UserLogin: IUserLogin, IEntity<long>
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
