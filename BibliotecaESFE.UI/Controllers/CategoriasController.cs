using BibliotecaESFE.BL;
using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
   [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CategoriasController : Controller
    {
        CategoriasBL categoriasBL = new CategoriasBL();
        // GET: CategoriasController
        public async Task<IActionResult> Index(Categorias categorias = null)
        {
            if(categorias == null)
                categorias = new Categorias();
            if(categorias.Top_Aux == 0)
                categorias.Top_Aux = 0;
            else if (categorias.Top_Aux == -1)
                categorias.Top_Aux = 0;

            var categories = await categoriasBL.SearchAsync(categorias);
            ViewBag.Top = categorias.Top_Aux;

            return View(categories);
        }

        public async Task<IActionResult> IndexUs(Categorias categorias = null)
        {
            if (categorias == null)
                categorias = new Categorias();
            if (categorias.Top_Aux == 0)
                categorias.Top_Aux = 0;
            else if (categorias.Top_Aux == -1)
                categorias.Top_Aux = 0;

            var categories = await categoriasBL.SearchAsync(categorias);
            ViewBag.Top = categorias.Top_Aux;

            return View(categories);
        }


        // GET: CategoriasController/Details/5
        public async  Task<IActionResult> Details(int id)
        {
            var categorias = await categoriasBL.GetByIdAsync(new Categorias { Id = id });
            return View(categorias);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categorias categorias)
        {
            try
            {
                int result = await categoriasBL.CreateAsync(categorias);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(categorias);
            }
        }

        // GET: CategoriasController/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: CategoriasController/Edit/5
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

        // GET: CategoriasController/Delete/5
        public  async Task<IActionResult> Delete(int id)
        {
            var category = await categoriasBL.GetByIdAsync(new Categorias { Id = id });
            ViewBag.Error = "";
            return View(category);
        }

        // POST: CategoriasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Categorias categorias)
        {
            try
            {
                int resutl = await categoriasBL.DeleteAsync(categorias);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }
    }
}
