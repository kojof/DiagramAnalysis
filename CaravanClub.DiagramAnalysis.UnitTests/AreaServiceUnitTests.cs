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
    public class AreaServiceUnitTests
    {
        private IAreaService _sut;
      


        [TestInitialize]
        public void Init()
        {
            _sut = new AreaService();
        }


        [TestMethod]
        public async Task Calculate_SumArea_with_Valid_Dimensions()
        {
            var shapes = ShapeDataLoader.GetShapes();

            var expectedResult = ShapeDataLoader.GetSumAreaOfShapes();

            var sumArea = await _sut.SumAreasAsync(shapes);

            Assert.AreEqual(sumArea, expectedResult);
        }

        [TestMethod]
        public async Task Calculate_SumArea_With_Empty_Shapes_Returns_Zero()
        {
            var shapes =new List<IShape>();

            var expectedResult = 0;

            var sumArea = await _sut.SumAreasAsync(shapes);

            Assert.AreEqual(sumArea, expectedResult);
        }

        [TestMethod]
        public async Task Calculate_SumArea_With_Null_Shapes_Returns_Zero()
        {
            var expectedResult = 0;

            var sumArea = await _sut.SumAreasAsync(null);

            Assert.AreEqual(sumArea, expectedResult);
        }


        [TestCleanup()]
        public void Cleanup()
        {
            _sut = null;
        }


        #region Private Methods

     
        #endregion
    }
}
