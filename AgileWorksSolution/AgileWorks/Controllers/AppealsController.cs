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
            var now = DateTime.Now;
            var oneHour = DateTime.Now.AddHours(+1);

            using (AgileWorksWebAppealsDBEntities entities = new AgileWorksWebAppealsDBEntities())
            {
                appealsList = entities.Appeals.ToList();

            }
            return View(appealsList.OrderByDescending(x => x.DeadLine_DateTime).ToList());
        }

        // GET: Appeals/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            try
            {
                using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
                {
                    if (ModelState.IsValid && appeals.DeadLine_DateTime >= now)
                    {
                        appeals.Entry_DateTime = DateTime.Now;

                        agileWorksDatabaseEntities.Appeals.Add(appeals);
                        agileWorksDatabaseEntities.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("DeadLine_DateTime", "The deadline is in past!");
                        return View(appeals);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appeals/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appeals/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appeals/Delete/5
        public ActionResult Delete(int id)
        {
            using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
            {

                return View(agileWorksDatabaseEntities.Appeals.Where(x => x.Appeal_Id == id).FirstOrDefault());
            }

        }

        // POST: Appeals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
                {
                    Appeals appeal = agileWorksDatabaseEntities.Appeals.Where(x => x.Appeal_Id == id).FirstOrDefault();
                    agileWorksDatabaseEntities.Appeals.Remove(appeal);
                    agileWorksDatabaseEntities.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
