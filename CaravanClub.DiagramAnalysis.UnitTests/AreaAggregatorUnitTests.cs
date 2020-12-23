using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CaravanClub.DiagramAnalysis.Application;
using CaravanClub.DiagramAnalysis.Application.Services;
using CaravanClub.DiagramAnalysis.Domain.Entities;
using CaravanClub.DiagramAnalysis.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CaravanClub.DiagramAnalysis.UnitTests
{
    [TestClass]
    public class AreaAggregatorUnitTests
    {
        private IAreaAggregator _sut;
        private Mock<IAreaService> _areaService;
        private Mock<IOutputWriterService> _printerService;


        [TestInitialize]
        public void Init()
        {
            _areaService = new Mock<IAreaService>();
            _printerService = new Mock<IOutputWriterService>();
            _sut = new AreaAggregator(_printerService.Object, _areaService.Object);
        }


        [TestMethod]
        public async Task Calculate_SumArea_with_Valid_Dimensions()
        {
            var shapes = ShapeDataLoader.GetShapes();

            var expectedResult = ShapeDataLoader.GetSumAreaOfShapes();

            _areaService.Setup(x => x.SumAreasAsync(shapes)).ReturnsAsync((expectedResult));

            var sumArea = await _sut.SumAreaAsync(shapes);

            Assert.AreEqual(sumArea, expectedResult);
        }

        [TestMethod]
        public async Task Calculate_SumArea_with_Empty_Shapes_returns_zero()
        {
            var shapes =new List<IShape>();

            var expectedResult =0;

            _areaService.Setup(x => x.SumAreasAsync(shapes)).ReturnsAsync((expectedResult));

            var sumArea = await _sut.SumAreaAsync(shapes);

            Assert.AreEqual(sumArea, expectedResult);
        }


        [TestMethod]
        public async Task Calculate_SumArea_with_Null_Shapes_returns_zero()
        {

            var expectedResult = 0;

            _areaService.Setup(x => x.SumAreasAsync(null)).ReturnsAsync((expectedResult));

            var sumArea = await _sut.SumAreaAsync(null);

            Assert.AreEqual(sumArea, expectedResult);
        }


        [TestMethod]
        public async Task Print_SumArea_of_Each_Shape_with_Valid_Dimensions()
        {
            var shapes = ShapeDataLoader.GetShapes();
            var shape = shapes[0];
            bool bResult = true;
            var expectedResult = true;

            _printerService.Setup(x => x.PrintAreasAsync(shape)).ReturnsAsync(bResult);

            await _sut.PrintAreasAsync(shapes);

            Assert.AreEqual(bResult, expectedResult);
        }



        [TestMethod]
        public async Task Print_SumArea_of_Empty_Shape_List_NeverPrints()
        {
            var shapes = new List<IShape>();
            var shape = new Rectangle();
            bool bResult = false;
            var expectedResult = false;

            _printerService.Setup(x => x.PrintAreasAsync(shape)).ReturnsAsync(bResult);

            await _sut.PrintAreasAsync(shapes);

            Assert.AreEqual(bResult, expectedResult);
        }


        [TestMethod]
        public async Task Print_SumArea_of_Null_Shape_List_NeverPrints()
        {

            _printerService.Setup(x => x.PrintAreasAsync(null));

            await _sut.PrintAreasAsync(null);

            _printerService.Verify(x => x.PrintAreasAsync(null), Times.Exactly(0));
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _sut = null;
        }
    }
}
