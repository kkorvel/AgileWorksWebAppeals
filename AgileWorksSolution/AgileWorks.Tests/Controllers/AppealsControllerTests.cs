using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileWorks.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AgileWorks.Models;
using Moq;
using System.Data.Entity.Validation;

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
            ViewResult viewResult = appealsController.Index(5) as ViewResult;

            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(PagedList.PagedList<Appeals>));

        }

        [TestMethod()]
        public void TestIfFutureAppealExists()
        {

            AgileWorksWebAppealsDBEntities agileWorksWebAppealsDBEntities = new AgileWorksWebAppealsDBEntities();

            Appeals appeals = new Appeals();
            appeals.deadlineDatetime = new DateTime(2020, 1, 19);
            appeals.entryDatetime = DateTime.Now;
            appeals.description = "Test123456123456789";

            AppealsController appealsController = new AppealsController();
            var result = appealsController.Create(appeals);
            var ifExists = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.appealId == appeals.appealId).FirstOrDefault();


            Assert.IsNotNull(ifExists);
            Assert.AreEqual(appeals.description, ifExists.description);


        }
        [TestMethod()]
        public void TestIfPastAppealCanBeAdded()
        {

            AgileWorksWebAppealsDBEntities agileWorksWebAppealsDBEntities = new AgileWorksWebAppealsDBEntities();

            Appeals appeals = new Appeals();
            appeals.deadlineDatetime = new DateTime(1996, 1, 19);
            appeals.entryDatetime = DateTime.Now;
            appeals.description = "Test123456123456789";

            AppealsController appealsController = new AppealsController();
            try
            {

            var result = appealsController.Create(appeals);
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        string errorMessage = validationError.ErrorMessage;
                        Assert.IsNotNull(errorMessage);
                    }
                }
            }

            

            


        }


        [TestMethod()]
        public void DeleteTest()
        {
            AgileWorksWebAppealsDBEntities agileWorksWebAppealsDBEntities = new AgileWorksWebAppealsDBEntities();
            Appeals appeals = new Appeals();
            appeals.deadlineDatetime = new DateTime(2019, 1, 19);
            appeals.entryDatetime = DateTime.Now;
            appeals.description = "Test123456Delete";

            AppealsController appealsController = new AppealsController();

            agileWorksWebAppealsDBEntities.Appeals.Add(appeals);
            agileWorksWebAppealsDBEntities.SaveChanges();

            var ifExists = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.appealId == appeals.appealId).FirstOrDefault();

            Assert.IsNotNull(ifExists);

            var result2 = appealsController.Delete(ifExists.appealId, new FormCollection());


            var isDeleted = agileWorksWebAppealsDBEntities.Appeals.Where(x => x.appealId == ifExists.appealId).FirstOrDefault();

            Assert.IsNull(isDeleted);


        }

    }
}