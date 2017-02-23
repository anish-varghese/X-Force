
using System;

namespace Experion.Marina.Dto
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public long DesignationId { get; set; }
        public DateTime DateOfJoin { get; set; }
        public long BandId { get; set; }
        public string BandName { get; set; }
        public string DesignationName { get; set; }
    }
}
