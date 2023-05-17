using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AdoTest()
        {
            int elvartErtek = 200 * 800;
            int szamitottErtek = global::BalatonCLI.BalatonCLI.Ado('A', 200);
            Assert.AreEqual(elvartErtek, szamitottErtek);
        }

        [TestMethod()]
        public void AdoTest2()
        {
            int elvartErtek = 200 * 600;
            int szamitottErtek = global::BalatonCLI.BalatonCLI.Ado('B', 200);
            Assert.AreEqual(elvartErtek, szamitottErtek);
        }

        [TestMethod()]
        public void AdoTest3()
        {
            int elvartErtek = 200 * 100;
            int szamitottErtek = global::BalatonCLI.BalatonCLI.Ado('C', 200);
            Assert.AreEqual(elvartErtek, szamitottErtek);
        }

        [TestMethod()]
        public void AdoTest4()
        {
            int elvartErtek = 0;
            int szamitottErtek = global::BalatonCLI.BalatonCLI.Ado('C', 20);
            Assert.AreEqual(elvartErtek, szamitottErtek);
        }
    }
}