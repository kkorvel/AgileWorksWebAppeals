using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileWorks.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AgileWorks.Models;

namespace AgileWorks.Controllers.Tests
{
    [TestClass()]
    public class AppealsControllerTests
    {
        //[TestMethod()]
        //public void IndexTest()
        //{
        //    AppealsController appealsController = new AppealsController();
        //    ViewResult viewResult = appealsController.Index() as ViewResult;
        //    Assert.IsNotNull(viewResult);

        //    Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
        //    Assert.AreEqual(string.Empty, viewResult.ViewName);
        //    //Assert.AreEqual("Index", viewResult.ViewName);
        //    //var controller = new AppealsController();
        //    //var result = controller.Index() as ViewResult;
        //    //Assert.AreEqual("Index", result.ViewName);
        //}
        [TestMethod()]
        public void IndexTest()
        {
            AppealsController appealsController = new AppealsController();
            ViewResult viewResult = appealsController.Index() as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
            Assert.AreEqual(string.Empty, viewResult.ViewName);

        }

        [TestMethod()]
        public void CreateTest1()
        {
            Appeals appeals = new Appeals();
            appeals.Appeal_Id = 500;
            appeals.DeadLine_DateTime = DateTime.Now;
            appeals.Entry_DateTime = DateTime.Now;
            appeals.Description = "Test123456";

            AppealsController appealsController = new AppealsController();
            var result = appealsController.Create(appeals);
            Assert.AreEqual(appeals.Description, "Test123456");
            Assert.IsNotNull(appeals.ToString());




        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

       


        //[TestMethod()]
        //public void DeleteTest1()
        //{


        //    Appeals appeals = new Appeals();
        //    appeals.Appeal_Id = 191;
        //    appeals.DeadLine_DateTime = DateTime.Now;
        //    appeals.Entry_DateTime = DateTime.Now;
        //    appeals.Description = "Test123456Delete";

        //    AppealsController appealsController = new AppealsController();


        //    var result = appealsController.Delete(191);
        //    Assert.AreNotEqual(appeals.Appeal_Id, null);


        //}

        //[TestMethod()]
        //public void IndexTest()
        //{
        //    AppealsController appealsController = new AppealsController();


        //    ViewResult viewResult = appealsController.Index() as ViewResult;
        //    Assert.IsNotNull(viewResult);

        //    Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
        //    Assert.AreEqual(string.Empty, viewResult.ViewName);
        //}

        //    [TestMethod()]
        //    public void DeleteTest()
        //    {
        //        Appeals appeals = new Appeals();
        //        appeals.Appeal_Id = 191;
        //        appeals.DeadLine_DateTime = DateTime.Now;
        //        appeals.Entry_DateTime = DateTime.Now;
        //        appeals.Description = "Test123456Delete";

        //        AppealsController appealsController = new AppealsController();
        //        appealsController.Delete(191);


        //        //var result = appealsController.Delete(191);
        //        //Assert.AreNotEqual(appeals.Appeal_Id, null);
        //    }
        //}
    }
}