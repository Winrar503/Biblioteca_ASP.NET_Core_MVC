using BibliotecaESFE.BL;
using BibliotecaESFE.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
    public class CalificacionesController : Controller
    {
        // GET: CalificacionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CalificacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalificacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalificacionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalificacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalificacionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalificacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalificacionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
