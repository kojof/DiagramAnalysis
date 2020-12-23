using System;
using System.Collections.Generic;
using System.Text;

namespace CaravanClub.DiagramAnalysis.Domain.Entities
{
    public class Square : IShape
    {
        private decimal _height;
        private decimal _width;
        public  decimal Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                _width = value;
            }
        }
        public decimal Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                _height = value;
            }
        }

        public decimal Area => Height * Width;
    }
}
