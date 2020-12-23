using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaravanClub.DiagramAnalysis.Domain.Entities;
using CaravanClub.DiagramAnalysis.Domain.Interfaces.Services;

namespace CaravanClub.DiagramAnalysis.Application.Services
{
    public class AreaAggregator: IAreaAggregator
    {
        private readonly IOutputWriterService _printerService;
        private readonly IAreaService _areaService;

        public AreaAggregator(IOutputWriterService printerService, IAreaService areaService)
        {
            _printerService = printerService;
            _areaService = areaService;
        }

        public async Task<decimal> SumAreaAsync(IEnumerable<IShape> shapes)
        {
            if ((shapes != null && shapes.Any()))
            {
                return await _areaService.SumAreasAsync(shapes);
            }

            return 0;
        }

        public async Task PrintAreasAsync(IEnumerable<IShape> shapes)
        {
            if ((shapes != null && shapes.Any()))
            {
                foreach (var shape in shapes)
                {
                    await _printerService.PrintAreasAsync(shape);
                }
                
            }
          
        }
    }
}
