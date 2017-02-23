
using Experion.Marina.Data.Contracts.Entities;

namespace Experion.Marina.Data.Services.Entities
{
    public class Attributes: IAttributes, IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
