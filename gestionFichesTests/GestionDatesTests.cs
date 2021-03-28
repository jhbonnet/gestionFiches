using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionClotureFicheDeFrais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionClotureFicheDeFrais.Tests
{
    [TestClass()]
    public class GestionDatesTests
    {
        [TestMethod()]
        public void getMoisPrecedentTest()
        {
            // on test les deux méthodes getMoisPrecedent
            Assert.AreEqual("202012", GestionDates.getMoisPrecedent(new DateTime(2021, 1, 1)));
            Assert.AreEqual("202102", GestionDates.getMoisPrecedent(new DateTime(2021, 3, 1)));
        }


        [TestMethod()]
        public void getMoisSuivantTest()
        {
            // on test les deux méthodes getMoisSuivant

            Assert.AreEqual("202102", GestionDates.getMoisSuivant(new DateTime(2021, 1, 1)));
            Assert.AreEqual("202201", GestionDates.getMoisSuivant(new DateTime(2021, 12, 1)));

        }

        [TestMethod()]
        public void entreTest()
        {
            // on test les deux méthodes entre
            Assert.AreEqual(true, GestionDates.entre(1, 1, new DateTime(2021, 1, 1)));
            Assert.AreEqual(true, GestionDates.entre(1, 20, new DateTime(2021, 1, 1)));
            Assert.AreEqual(false, GestionDates.entre(1, 20, new DateTime(2020, 12, 31)));
            Assert.AreEqual(true, GestionDates.entre(30, 31, new DateTime(2020, 12, 31)));

        }

    }
}
