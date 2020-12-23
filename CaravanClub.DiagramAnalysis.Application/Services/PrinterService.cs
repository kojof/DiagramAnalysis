using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaravanClub.DiagramAnalysis.Domain.Entities;
using CaravanClub.DiagramAnalysis.Domain.Interfaces.Services;

namespace CaravanClub.DiagramAnalysis.Application.Services
{
    public class PrinterService : IOutputWriterService
    {
        public PrinterService()
        {

        }

        public async Task<bool> PrintAreasAsync(IShape shape)
        {
            bool bResult = false;
            if (shape != null)
            {
                bResult = await Task.Run(() => Print(shape.Area));
                return bResult;
            }

            return bResult;
        }

        private bool Print(decimal area)
        {
            var bResult = false;

            if (area > 0)
            {
                Console.WriteLine(area);
                return bResult = true;
            }
            return bResult;
        }
    }
}
