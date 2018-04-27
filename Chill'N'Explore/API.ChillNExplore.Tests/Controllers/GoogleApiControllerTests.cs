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


    }
}