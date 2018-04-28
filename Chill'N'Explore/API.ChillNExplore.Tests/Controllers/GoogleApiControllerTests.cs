using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.ChillNExplore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ChillNExplore.Controllers.Tests
{
    [TestClass()]
    public class GoogleApiControllerTests
    {
        GoogleApiController googleApiController = new GoogleApiController();
        [TestMethod()]
        public void GetPositionTest()
        {
            var actual = googleApiController.GetPos();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetLatLngTest()
        {
            var actual = googleApiController.GetLatLngForCity("dijon");
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetNamesLieuxInterestTest()
        {
            var expected = new List<string>
            {
                "Musée des Beaux-Arts de Dijon",
                "Musée de la Vie bourguignonne",
                "Musée archéologique de Dijon",
                "Musée Magnin" // "Muséum d'histoire naturelle"
            };

            var actual = googleApiController.GetNamesLieuxInterest("dijon", "museum");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetLocationLieuxInterestTest()
        {
            var expected = new List<string>
            {
                "47.3214246,5.0423975",
                "47.3174169,5.0376904",
                "47.321641,5.034822999999999", // 47.321641,5.034822999999999
                "47.3207686,5.0421907"
            };

            var actual = googleApiController.GetLocationLieuxInterest("dijon", "museum");

            Assert.IsTrue(expected.SequenceEqual(actual));
            //expected.SequenceEqual
            CollectionAssert.AreEqual(expected,actual);
        }


    }
}