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
            Appeals appeals = new Appeals();
            AppealsController appealsController = new AppealsController();
            ViewResult viewResult = appealsController.Index() as ViewResult;

            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<Appeals>));

        }

        [TestMethod()]
        public void CreateTest()
        {
            AgileWorksWebAppealsDBEntities agileWorksWebAppealsDBEntities = new AgileWorksWebAppealsDBEntities();

            Appeals appeals = new Appeals();
            appeals.DeadLine_DateTime = new DateTime(2020, 1, 19);
            appeals.Entry_DateTime = DateTime.Now;
            appeals.Description = "Test123456123456789";

            AppealsController appealsController = new AppealsController();
            var result = appealsController.Create(appeals);
            var ifExists = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.Appeal_Id == appeals.Appeal_Id).FirstOrDefault();

            Assert.IsNotNull(ifExists);
            Assert.AreEqual(appeals.Description, ifExists.Description);
        }


        [TestMethod()]
        public void CreateTest2()
        {
            AgileWorksWebAppealsDBEntities agileWorksWebAppealsDBEntities = new AgileWorksWebAppealsDBEntities();

            Appeals appeals = new Appeals();
            appeals.DeadLine_DateTime = new DateTime(1996, 1, 19);
            appeals.Entry_DateTime = DateTime.Now;
            appeals.Description = "Test123456123456789";

            AppealsController appealsController = new AppealsController();
            var result = appealsController.Create(appeals);
            var ifExists = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.Appeal_Id == appeals.Appeal_Id).FirstOrDefault();

            Assert.IsNull(ifExists);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            AgileWorksWebAppealsDBEntities agileWorksWebAppealsDBEntities = new AgileWorksWebAppealsDBEntities();
            Appeals appeals = new Appeals();
            appeals.DeadLine_DateTime = new DateTime(2019, 1, 19);
            appeals.Entry_DateTime = DateTime.Now;
            appeals.Description = "Test123456Delete";

            AppealsController appealsController = new AppealsController();

            agileWorksWebAppealsDBEntities.Appeals.Add(appeals);
            agileWorksWebAppealsDBEntities.SaveChanges();

            var ifExists = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.Appeal_Id == appeals.Appeal_Id).FirstOrDefault();

            Assert.IsNotNull(ifExists);

            var result2 = appealsController.Delete(ifExists.Appeal_Id, new FormCollection());


            var isDeleted = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.Appeal_Id == ifExists.Appeal_Id).FirstOrDefault();

            Assert.IsNull(isDeleted);


        }

    }
}