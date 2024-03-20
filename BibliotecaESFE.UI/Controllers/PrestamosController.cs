using BibliotecaESFE.BL;
using BibliotecaESFE.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
    public class PrestamosController : Controller
    {
        // GET: PrestamosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PrestamosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestamosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrestamosController/Create
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

        // GET: PrestamosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestamosController/Edit/5
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

        // GET: PrestamosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestamosController/Delete/5
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
