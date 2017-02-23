using Experion.Marina.Dto;
using System.Collections.Generic;


namespace Experion.Marina.Business.Services.Contracts
{
    public interface IPageLoad
    {
        List<AttributesDto> GetAttributes();
        List<BandDto> GetBand();
        List<DesignationDto> GetDesignation();
        List<FilterOperatorDto> GetFilterOperators(long AttributeId);
    }
}
