using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicTestsMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace ToolCtrl.Tests
{
    [TestClass]
    public class HttpContextCreation
    {
        [TestMethod]
        public void TestCache()
        {
            var context = CreateHttpContext("index.aspx", "http://tempuri.org/index.aspx", null);
            var result = RunInstanceMethod(Thread.CurrentThread, "GetIllogicalCallContext", new object[] { });
            SetPrivateInstanceFieldValue(result, "m_HostContext", context);


            HttpContext.Current.Cache["val"] = "testValue";
        }

        private static HttpContext CreateHttpContext(string fileName, string url, string queryString)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            var hres = new HttpResponse(sw);
            var hreq = new HttpRequest(fileName, url, queryString);
            var httpc = new HttpContext(hreq, hres);
            return httpc;
        }

        private static object RunInstanceMethod(object source, string method, object[] objParams)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var type = source.GetType();
            var m = type.GetMethod(method, flags);
            if (m == null)
            {
                throw new ArgumentException(string.Format("There is no method '{0}' for type '{1}'.", method, type));
            }

            var objRet = m.Invoke(source, objParams);
            return objRet;
        }

        public static void SetPrivateInstanceFieldValue(object source, string memberName, object value)
        {
            var field = source.GetType()
                .GetField(memberName, BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ArgumentException(string.Format("Could not find the private instance field '{0}'", memberName));
            }

            field.SetValue(source, value);
        }
    }
}