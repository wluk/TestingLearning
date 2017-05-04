using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using BasicTestsMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yellow.Web.Infrastructure.Mvc.Security.Caching;

namespace BasicTestsMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestsCtrl()
        {
            var attribute = new NoCacheAttribute();
            var filterContext = new ResultExecutingContext();

            attribute.OnResultExecuting(filterContext);

            var x = 1;
        }
    }
}
