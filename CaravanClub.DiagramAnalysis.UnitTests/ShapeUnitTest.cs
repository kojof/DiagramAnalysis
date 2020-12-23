using System;
using CaravanClub.DiagramAnalysis.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaravanClub.DiagramAnalysis.UnitTests
{
    [TestClass]
    public class ShapeUnitTest
    {
        [TestMethod]
        public void Rectangle_with_Valid_Height_Width_is_Valid()
        {
            var sut = new Rectangle
            {
                Height = 3,
                Width = 7
            };
            Assert.AreEqual(21, sut.Area);
        }

        [TestMethod]
        public void Rectangle_with_InValid_Height_Width_is_ReturnZero()
        {
            var sut = new Rectangle
            {
              
                Width = 0
            };
            Assert.AreEqual(0, sut.Area);
        }

        [TestMethod]
        public void Circle_with_Valid_Height_Width_is_Valid()
        {
            const decimal radius = 3;
            const decimal expectedResult = radius * radius * (decimal)Math.PI;

            var sut = new Circle
            {
                Radius = radius
            };
            Assert.AreEqual(expectedResult, sut.Area);
        }

        [TestMethod]
        public void Circle_with_InValid_Height_Width_is_ReturnZero()
        {
            const decimal radius = 0;
            const decimal expectedResult = radius * radius * (decimal)Math.PI;

            var sut = new Circle
            {
                Radius = radius
            };
            Assert.AreEqual(expectedResult, sut.Area);
        }

        [TestMethod]
        public void Square_with_Valid_Height_Width_is_Valid()
        {
            var sut = new Square
            {
                Height = 3,
                Width = 3
            };
            Assert.AreEqual(9, sut.Area);
        }

        [TestMethod]
        public void Square_with_Different_Height_Width_is_Valid()
        {
            var sut = new Square
            {
                Height = 3,
                Width = 7
            };
            Assert.AreEqual(49, sut.Area);
        }

        [TestMethod]
        public void Square_with_InValid_Height_Width_is_ReturnZero()
        {
            var sut = new Square
            {

                Width = 0
            };
            Assert.AreEqual(0, sut.Area);
        }
    }
}
