﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CaravanClub.DiagramAnalysis.Domain.Entities;

namespace CaravanClub.DiagramAnalysis.Domain.Interfaces.Services
{
   public interface IAreaAggregator
    {
        Task<Decimal> SumAreaAsync(IEnumerable<IShape> shapes);
        Task PrintAreasAsync(IEnumerable<IShape> shapes);
    }
}
