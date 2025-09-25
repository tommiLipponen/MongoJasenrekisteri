using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoJäsenrekisteri.Models;
using MongoJäsenrekisteri.Services;

namespace MongoJäsenrekisteri.Controllers
{
    public class JasenController : Controller
    {
        private readonly JasenetServices services;

        public JasenController(JasenetServices _Services)
        {
            this.services = _Services;
        }
        // GET: JasenController
        [HttpGet]
        public IActionResult Index()
        {
            var ListJasenet = services.AllJasenet();
            return View(ListJasenet);
        }

        // GET: JasenController/Details/5
        [HttpGet]
        public IActionResult Details(string Id)
        {
            var jasen = services.GetOneJasen(Id);
            return View(jasen);
        }

        // GET: JasenController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JasenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Jasenet model)
        {
            if (ModelState.IsValid)
            {
                services.CreateJasen(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: JasenController/Edit/5
        public ActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var jasen = services.GetOneJasen(Id);

            if (jasen == null)
            {
                return NotFound();
            }
            return View(jasen);
        }

        // POST: JasenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Id, Jasenet model)
        {
            if (Id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                services.EditJasen(Id, model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: JasenController/Delete/5 (confirmation)
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jasen = services.GetOneJasen(id);

            if (jasen == null)
            {
                return NotFound();
            }

            return View(jasen);
        }

        // POST: JasenController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var jasen = services.GetOneJasen(id);
            if (jasen == null)
            {
                return NotFound();
            }

            services.DeleteJasen(jasen);
            return RedirectToAction("Index");
        }
    }
}
