using System;
using System.Collections.Generic;
using System.Text;

namespace CaravanClub.DiagramAnalysis.Domain.Entities
{
    public class Rectangle: IShape
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Area => Height * Width;
    }
}
