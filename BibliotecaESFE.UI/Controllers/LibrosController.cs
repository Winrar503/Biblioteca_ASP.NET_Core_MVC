using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BibliotecaESFE.EN;
using BibliotecaESFE.BL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace BibliotecaESFE.UI.Controllers
{
   [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class LibrosController : Controller
    {
        LibrosBL librosBL = new LibrosBL();
        // GET: LibrosController
        public async Task<IActionResult> Index(Libros libros = null)
        {
            if (libros == null)
                libros = new Libros();
            if (libros.Top_Aux == 0)
                libros.Top_Aux = 0;
            else if (libros.Top_Aux == -1)
                libros.Top_Aux = 0;

            var libro = await librosBL.SearchAsync(libros);
            ViewBag.Top = libros.Top_Aux;
            return View(libro);
        }

        // GET: LibrosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var libros = await librosBL.GetByIdAsync(new Libros { Id = id });
            return View(libros);
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libros libros)
        {
            try
            {
                int result = await librosBL.CreateAsync(libros);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(libros);
            }
        }

        // GET: LibrosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var libros = await librosBL.GetByIdAsync(new Libros { Id = id });
            return View(libros);
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Libros libros)
        {
            try
            {
                int result = await librosBL.UpdateAsync(libros);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(libros);
            }
        }

        // GET: LibrosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var libros = await librosBL.GetByIdAsync(new Libros { Id =id });
            return View(libros);
        }

        // POST: LibrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Libros libros)
        {
            try
            {
                int result = await librosBL.DeleteAsync(libros);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
