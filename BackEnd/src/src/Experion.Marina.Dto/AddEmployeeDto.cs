using System.Collections.Generic;


namespace Experion.Marina.Dto
{
    public class AddEmployeeDto
    {
        public List<BandDto> Bands { get; set; }
        public List<DesignationDto> Designation { get; set; }
    }
}
