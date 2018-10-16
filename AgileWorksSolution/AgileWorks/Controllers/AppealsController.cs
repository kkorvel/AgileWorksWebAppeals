using AgileWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AgileWorks.Controllers
{
    public class AppealsController : Controller
    {
        List<Appeals> appealsList = new List<Appeals>();
        // GET: Appeals
        public ActionResult Index()
        {

            using (AgileWorksWebAppealsDBEntities entities = new AgileWorksWebAppealsDBEntities())
            {
                appealsList = entities.Appeals.ToList();

            }
            
            return View(appealsList.OrderByDescending(x => x.deadlineDatetime).ToList());
        }

        // GET: Appeals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appeals/Create
        [HttpPost]
        public ActionResult Create(Appeals appeals)
        {
            var now = DateTime.Now;

            using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
            {
                if (ModelState.IsValid && appeals.deadlineDatetime >= now)
                {
                    appeals.entryDatetime = DateTime.Now;

                    agileWorksDatabaseEntities.Appeals.Add(appeals);
                    agileWorksDatabaseEntities.SaveChanges();
                }
                else
                {

                    ModelState.AddModelError("deadlineDatetime", "The deadline is in past!");

                    return View(appeals);
                }
            }

            return RedirectToAction("Index");
        }


        // GET: Appeals/Delete/5
        public ActionResult Delete(int id)
        {
            using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
            {
                return View(agileWorksDatabaseEntities.Appeals.Where(x => x.appealId == id).First());
            }
        }

        // POST: Appeals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
            {
                Appeals appeal = agileWorksDatabaseEntities.Appeals.Where(x => x.appealId == id).FirstOrDefault();
                agileWorksDatabaseEntities.Appeals.Remove(appeal);
                agileWorksDatabaseEntities.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}
