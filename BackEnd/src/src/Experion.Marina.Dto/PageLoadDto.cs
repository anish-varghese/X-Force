
using System.Collections.Generic;

namespace Experion.Marina.Dto
{
    public class PageLoadDto
    {
        public List<AttributesDto> Attributes { get; set; }
        public List<BandDto> Bands { get; set; }
        public List<DesignationDto> Designation { get; set; }
        public List<FilterOperatorDto> FilterOperators { get; set; }
    }
}
