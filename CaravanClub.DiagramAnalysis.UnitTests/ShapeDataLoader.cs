using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaravanClub.DiagramAnalysis.Domain.Entities;

namespace CaravanClub.DiagramAnalysis.UnitTests
{
    public class ShapeDataLoader
    {
        public static List<IShape> GetShapes()
        {
            Rectangle rectangle = new Rectangle
            {
                Height = 3,
                Width = 7
            };

            Square square = new Square
            {
                Height = 3,
                Width = 3
            };

            Circle circle = new Circle
            {
                Radius = 3
            };

            List<IShape> shapes = new List<IShape>();
            shapes.Add(rectangle);
            shapes.Add(circle);
            shapes.Add(square);
            return shapes;
        }

        public static decimal GetSumAreaOfShapes()
        {
            decimal sumArea = 0;
            var shapes = ShapeDataLoader.GetShapes();
            sumArea = shapes.Select(x => x.Area).Sum();
            return sumArea;
        }
    }
}
