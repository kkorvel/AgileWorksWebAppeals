using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileWorks.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AgileWorks.Models;
using AgileWorks.Models.WebDatabase;

namespace AgileWorks.Controllers.Tests
{
    [TestClass()]
    public class AppealsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            AppealsController appealsController = new AppealsController();
            ViewResult viewResult = appealsController.Index() as ViewResult;
            Assert.IsNotNull(viewResult);

            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
            Assert.AreEqual(string.Empty, viewResult.ViewName);
            //Assert.AreEqual("Index", viewResult.ViewName);
            //var controller = new AppealsController();
            //var result = controller.Index() as ViewResult;
            //Assert.AreEqual("Index", result.ViewName);

        }
    }