using System.Data.Entity.Infrastructure;

namespace Experion.Marina.Data.Services
{
    public class MigrationContextFactory : IDbContextFactory<MarinaContext>
    {
        public MarinaContext Create()
        {
            //return new MarinaContext(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=MarinaDB;User Id=sa;Password=experion;MultipleActiveResultSets=true");
            return new MarinaContext(@"Data Source = DESKTOP-HF4JVUU\SQLEXPRESS; Initial Catalog = X-ForceDb; uid = sa; password = root; MultipleActiveResultSets = true");
        }
    }
}