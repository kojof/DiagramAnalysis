
using CaravanClub.DiagramAnalysis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaravanClub.DiagramAnalysis.Application;
using CaravanClub.DiagramAnalysis.Application.Services;
using CaravanClub.DiagramAnalysis.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CaravanClub.DiagramAnalysis
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            var areaService = serviceProvider.GetService<IAreaService>();
            var printerService = serviceProvider.GetService<IOutputWriterService>();
            
            var shapes = GetShapes();
            var sumArea = await areaService.SumAreasAsync(shapes);
            Console.WriteLine("Sum Area: " + sumArea);
            List<IShape> shapes2 = new List<IShape>();
            await printerService.PrintAreasAsync(null);
        }

        #region Private Methods
        private static List<IShape> GetShapes()
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

            Console.WriteLine(rectangle.Area);
            Console.WriteLine(square.Area);
            Console.WriteLine(circle.Area);

            List<IShape> shapes = new List<IShape>();
            shapes.Add(rectangle);
            shapes.Add(circle);
            shapes.Add(square);
            return shapes;
        }


        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IOutputWriterService, PrinterService>();
            serviceCollection.AddScoped<IAreaService, AreaService>();
            serviceCollection.AddScoped<IAreaAggregator, AreaAggregator>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
        #endregion
    }
}
