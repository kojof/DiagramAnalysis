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
    public class PrinterServiceUnitTests
    {
        private IOutputWriterService _sut;
      


        [TestInitialize]
        public void Init()
        {
            _sut = new PrinterService();
        }


        [TestMethod]
        public async Task Print_SumArea_of_Each_Shape_with_Valid_Dimensions()
        {
            var shapes = ShapeDataLoader.GetShapes();
            var shape = shapes[0];
            var expectedResult = true;
            var result = await _sut.PrintAreasAsync(shape);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public async Task Print_SumArea_of_Empty_Shape_List_NeverPrints()
        {
            var shape = new Rectangle();
            
            var expectedResult = false;
            var result = await _sut.PrintAreasAsync(shape);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public async Task Print_SumArea_of_Null_Shape_List_NeverPrints()
        {
            var expectedResult = false;
            var result = await _sut.PrintAreasAsync(null);

            Assert.AreEqual(result, expectedResult);
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
