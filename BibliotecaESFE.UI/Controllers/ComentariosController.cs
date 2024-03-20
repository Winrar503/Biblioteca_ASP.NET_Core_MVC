using BibliotecaESFE.BL;
using BibliotecaESFE.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
    public class ComentariosController : Controller
    {
        // GET: ComentariosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComentariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComentariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComentariosController/Create
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

        // GET: ComentariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComentariosController/Edit/5
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

        // GET: ComentariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComentariosController/Delete/5
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
