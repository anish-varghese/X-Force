using Experion.Marina.Data.Contracts.Entities;

namespace Experion.Marina.Data.Services.Entities
{
    public class FilterOperator: IFilterOperators,IEntity<long>
    {
        public long Id { get; set; }
        public string Operator { get; set; }
        public long AttributesId { get; set; }

        public Attributes Attributes { get; set; }
    }
}
