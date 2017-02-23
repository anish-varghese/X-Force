using Experion.Marina.Data.Contracts.Entities;
using System;

namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IEmployee
    {
        long Id { get; set; }
        long Number { get; set; }
        string Name { get; set; }
        long DesignationId { get; set; }
        DateTime DateOfJoin { get; set; }
        long BandId { get; set; }
    }
}
