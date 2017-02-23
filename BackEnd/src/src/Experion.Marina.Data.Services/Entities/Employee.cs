using Experion.Marina.Data.Contracts.Entities;
using System;

namespace Experion.Marina.Data.Services.Entities
{
    public class Employee: IEmployee, IEntity<long>
    {
        public long Id { get; set; }
        public long Number{ get; set; }
        public string Name { get; set; }
        public long DesignationId { get; set; }
        public DateTime DateOfJoin { get; set; }
        public long BandId { get; set; }

        public virtual Band Band { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
