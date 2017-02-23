
namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IFilterOperators
    {
        long Id { get; set; }
        long AttributesId { get; set; }
        string Operator { get; set; }
    }
}
