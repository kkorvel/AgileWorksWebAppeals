﻿using AgileWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Net;

namespace AgileWorks.Controllers
{
    public class AppealsController : Controller
    {
        List<Appeals> appealsList = new List<Appeals>();
        // GET: Appeals
        public ActionResult Index(int? page)
        {

            using (AgileWorksWebAppealsDBEntities entities = new AgileWorksWebAppealsDBEntities())
            {
                appealsList = entities.Appeals.ToList();

            }

            return View(appealsList.OrderByDescending(x => x.deadlineDatetime).ToList().ToPagedList(page ?? 1, 50));
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
                if (ModelState.IsValid)
                {

                    agileWorksDatabaseEntities.Appeals.Add(appeals);
                    agileWorksDatabaseEntities.SaveChanges();
                }
                else if (!ModelState.IsValid)
                {

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
                Appeals appeals = agileWorksDatabaseEntities.Appeals.Where(x => x.appealId == id).First();

                if (appeals != null)
                {
                    return View(appeals);
                }
                else
                {
                    return new HttpNotFoundResult("Appeal not found!");

                }
            }
        }

        // POST: Appeals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            using (AgileWorksWebAppealsDBEntities agileWorksDatabaseEntities = new AgileWorksWebAppealsDBEntities())
            {
                Appeals appeal = agileWorksDatabaseEntities.Appeals.Where(x => x.appealId == id).FirstOrDefault();

                if (appeal != null)
                {
                    agileWorksDatabaseEntities.Appeals.Remove(appeal);
                    agileWorksDatabaseEntities.SaveChanges();
                }
                else
                {
                    return new HttpNotFoundResult("Appeal not found!");
                }
            }

            return RedirectToAction("Index");

        }


    }
}
