using Experion.Marina.Data.Contracts.Entities;
using System.Collections.Generic;

namespace Experion.Marina.Data.Contracts
{
    public interface IPageLoadDataService
    {
        IEnumerable<IAttributes> GetAttributes();
        IEnumerable<IBand> GetBand();
        IEnumerable<IDesignation> GetDesignation();
        IEnumerable<IFilterOperators> GetFilterOperators( long AttributeId );
    }
}
