using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaravanClub.DiagramAnalysis.Domain.Entities;
using CaravanClub.DiagramAnalysis.Domain.Interfaces.Services;

namespace CaravanClub.DiagramAnalysis.Application.Services
{
    
    public class AreaService : IAreaService
    {
        public async Task<decimal> SumAreasAsync(IEnumerable<IShape> shapes)
        {
            decimal retVal = 0;

            if ((shapes != null && shapes.Any()))
            {
                retVal = Task.Run(() =>  shapes.Select(x => x.Area).Sum()).Result;
                return retVal;
            }

            return retVal;
        }
    }
}
