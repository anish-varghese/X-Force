
namespace Experion.Marina.Data.Contracts.Entities
{
    public interface ISearchParameters
    {
        string SearchBy { get; set; }
        string FilterBy { get; set; }
        string Query { get; set; }
    }
}
