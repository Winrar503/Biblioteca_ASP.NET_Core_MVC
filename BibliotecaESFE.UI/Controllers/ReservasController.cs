using BibliotecaESFE.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
    public class ReservasController : Controller
    {
        
        // GET: ReservasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasController/Create
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

        // GET: ReservasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservasController/Edit/5
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

        // GET: ReservasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservasController/Delete/5
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
