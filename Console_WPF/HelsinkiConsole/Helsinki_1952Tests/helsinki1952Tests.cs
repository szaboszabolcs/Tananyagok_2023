using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helsinki_1952;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki_1952.Tests
{
    [TestClass()]
    public class helsinki1952Tests
    {
        [TestMethod()]
        public void HelyezesPontSzamErtekTest()
        {
            int elvart = 8;
            int szamitott = helsinki1952.HelyezesPontSzamErtek(1);
            Assert.AreEqual(elvart, szamitott);
        }

        [TestMethod()]
        public void HelyezesPontSzamErtekTest2()
        {
            int elvart = 5;
            int szamitott = helsinki1952.HelyezesPontSzamErtek(2);
            Assert.AreEqual(elvart, szamitott);
        }

        [TestMethod()]

        public void HelyezesPontSzamErtekTest3()
        {
            int elvart = 0;
            int szamitott = helsinki1952.HelyezesPontSzamErtek(8);
            Assert.AreEqual(elvart, szamitott);
        }
    }
}