using BibliotecaESFE.EN;
using BibliotecaESFE.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
    public class AutoresController : Controller
    {
        AutoresBL autoresBL = new AutoresBL();
        // GET: AutoresController
        public async Task<ActionResult> Index(Autores autores = null)
        {
            if (autores == null)
                autores = new Autores();
            if (autores.Top_Aux == 0)
                autores.Top_Aux = 10; // setear el número de resgistro a mostrar
            else if (autores.Top_Aux == -1)
                autores.Top_Aux = 0;

            var autoros = await autoresBL.SearchAsync(autores);
            ViewBag.Top = autores.Top_Aux;
            return View(autoros);
        }

        // GET: AutoresController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var autores = await autoresBL.GetByIdAsync(new Autores { Id = id });
            return View(autores);
        }

        // GET: AutoresController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: AutoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autores autores)
        {
            try
            {
                int result = await autoresBL.CreateAsync(autores);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AutoresController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var autores = await autoresBL.GetByIdAsync(new Autores { Id = id });
            return View(autores);
        }

        // POST: AutoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Autores autores )
        {
            try
            {
                int result = await autoresBL.UpdateAsync(autores);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(autores);
            }
        }

        // GET: AutoresController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var autores = await autoresBL.GetByIdAsync(new Autores { Id = id });
            return View(autores);
        }

        // POST: AutoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Delete(int id, Autores autores)
        {
            try
            {
                int result = await autoresBL.DeleteAsync(autores);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
