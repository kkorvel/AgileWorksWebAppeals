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
        public void CreateTest()
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
        public void CreateTest2()
        {
            var today = DateTime.Now;
            List<Appeals> allAppeals = new List<Appeals>();
            List<Appeals> correctDateTimeAppeals = new List<Appeals>();
            Appeals appeals = new Appeals();
            appeals.Appeal_Id = 590;
            appeals.DeadLine_DateTime = new DateTime(2020, 1, 19);
            appeals.Entry_DateTime = DateTime.Now;
            appeals.Description = "Test123456";

            Appeals appeals2 = new Appeals();
            appeals2.Appeal_Id = 501;
            appeals2.DeadLine_DateTime = new DateTime(2017, 1, 19);
            appeals2.Entry_DateTime = DateTime.Now;
            appeals2.Description = "Testimine";


            AppealsController appealsController = new AppealsController();
            var result = appealsController.Create(appeals);
            var result2 = appealsController.Create(appeals2);
            allAppeals.Add(appeals);
            allAppeals.Add(appeals2);

            foreach (var item in allAppeals)
            {
                if (item.DeadLine_DateTime > today)
                {
                    correctDateTimeAppeals.Add(item);
                }
            }

            Assert.AreEqual(appeals.Description, "Test123456");
            Assert.AreEqual(appeals2.Description, "Testimine");
            Assert.IsNotNull(appeals.ToString());
            CollectionAssert.Contains(correctDateTimeAppeals, appeals);
            CollectionAssert.DoesNotContain(correctDateTimeAppeals, appeals2);





        }
        [TestMethod()]
        public void DeleteTest()
        {
            Appeals appeals = new Appeals();
            appeals.Appeal_Id = 191;
            appeals.DeadLine_DateTime = DateTime.Now;
            appeals.Entry_DateTime = DateTime.Now;
            appeals.Description = "Test123456Delete";

            AppealsController appealsController = new AppealsController();


            var result = appealsController.Delete(191);
            Assert.AreNotEqual(appeals.Appeal_Id, null);
        }

}
}