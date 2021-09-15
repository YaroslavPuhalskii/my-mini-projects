using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoList.WEB.Controllers
{
    public class PurposeController : Controller
    {
        // GET: Purpose
        public ActionResult Index()
        {
            return View();
        }

        // GET: Purpose/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purpose/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purpose/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purpose/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purpose/Edit/5
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

        // GET: Purpose/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Purpose/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
