namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IUserLogin
    {
        long Id { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
