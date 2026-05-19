using Microsoft.VisualStudio.TestTools.UnitTesting;
using DolgozatCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozatCLI.Tests
{
    [TestClass()]
    public class DolgozatTests
    {
        [TestMethod()]
        public void otoserdemJegyTest()
        {
            Dolgozat otosdolgozat = new Dolgozat("Valaki", 18, 92);
            Assert.AreEqual(5, otosdolgozat.erdemJegy());
        }

        [TestMethod()]
        public void nemjoerdemJegyTest()
        {
            Dolgozat otosdolgozat = new Dolgozat("Valaki", 18, 92);
            Assert.AreNotEqual(4, otosdolgozat.erdemJegy());
        }

        [TestMethod()]
        public void egyeserdemJegyTest()
        {
            Dolgozat otosdolgozat = new Dolgozat("Valaki", 18, 10);
            Assert.AreEqual(1, otosdolgozat.erdemJegy());
        }
    }
}