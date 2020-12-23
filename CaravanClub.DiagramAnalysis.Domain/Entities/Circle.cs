using System;
using System.Collections.Generic;
using System.Text;

namespace CaravanClub.DiagramAnalysis.Domain.Entities
{
    public class Circle : IShape
    {
        public decimal Radius { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Area => (decimal)Math.PI * Radius * Radius;
    }
}
