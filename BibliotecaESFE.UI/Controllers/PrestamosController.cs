using BibliotecaESFE.BL;
using BibliotecaESFE.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class PrestamosController : Controller
    {
        PrestamosBL prestamosBL = new PrestamosBL();
        // GET: PrestamosController
        public async Task<IActionResult> Index(Prestamos prestamos = null)
        {
            if (prestamos == null)
                prestamos = new Prestamos();
            if (prestamos.Top_Aux == 0)
                prestamos.Top_Aux = 0;
            else if (prestamos.Top_Aux == -1)
                prestamos.Top_Aux = 0;

            var prestamose = await prestamosBL.SearchAsync(prestamos);
            ViewBag.Top = prestamos.Top_Aux;

            return View(prestamose);
        }

        // GET: PrestamosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prestamos = await prestamosBL.GetByIdAsync(new Prestamos { Id = id });
            return View(prestamos);
        }

        // GET: PrestamosController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: PrestamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prestamos prestamos)
        {
            try
            {
                int result = await prestamosBL.CreateAsync(prestamos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(prestamos);
            }
        }

        // GET: PrestamosController/Edit/5
        public async Task<ActionResult> Edit(int id)
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
        public async Task<IActionResult> Delete(int id)
        {
            var prestamose = await prestamosBL.GetByIdAsync(new Prestamos { Id = id });
            ViewBag.Error = "";
            return View(prestamose);
        }

        // POST: PrestamosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Prestamos Prestamos)
        {
            try
            {
                int resutl = await prestamosBL.DeleteAsync(Prestamos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }
    }
}
