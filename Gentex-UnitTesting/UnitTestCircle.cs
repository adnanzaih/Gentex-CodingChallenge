using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Gentex_CodingChallenge;

namespace Gentex_UnitTesting
{
    [TestClass]
    public class UnitTestCircle
    {
        [TestMethod]
        public void UnitCircleTest()
        {
            double tol = 0.01;
            string line = "1,Circle,CenterX,0,CenterY,0,Radius,1";
            string[] _line = line.Split(',');
            Circle c = new Circle(_line);
            Assert.AreEqual(0, c.CentroidX);
            Assert.AreEqual(0, c.CentroidY);
            Assert.IsTrue((Math.Abs(c.Area - 3.14) < tol));
            Assert.IsTrue((Math.Abs(c.Circumference - 6.28) < tol));
        }
        //Need to implement
        public void LargeCircleTest()
        {
            double tol = 0.01;
            string line = "1,Circle,CenterX,0,CenterY,0,Radius,1";
            string[] _line = line.Split(',');
            Circle c = new Circle(_line);
            Assert.AreEqual(0, c.CentroidX);
            Assert.AreEqual(0, c.CentroidY);
            Assert.IsTrue((Math.Abs(c.Area - 3.14) < tol));
            Assert.IsTrue((Math.Abs(c.Circumference - 6.28) < tol));
        }
        //Need to implement
        public void SmallCircleTest()
        {
            double tol = 0.01;
            string line = "1,Circle,CenterX,0,CenterY,0,Radius,1";
            string[] _line = line.Split(',');
            Circle c = new Circle(_line);
            Assert.AreEqual(0, c.CentroidX);
            Assert.AreEqual(0, c.CentroidY);
            Assert.IsTrue((Math.Abs(c.Area - 3.14) < tol));
            Assert.IsTrue((Math.Abs(c.Circumference - 6.28) < tol));
        }
    }
}
