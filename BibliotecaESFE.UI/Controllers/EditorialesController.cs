using BibliotecaESFE.BL;

using BibliotecaESFE.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaESFE.UI.Controllers
{
   //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class EditorialesController : Controller
    {
        EditorialesBL editorialesBL = new EditorialesBL();
        // GET: EditorialesController
        public async Task<IActionResult> Index(Editoriales editoriales = null)
        {
            if (editoriales == null)
                editoriales = new Editoriales();
            if (editoriales.Top_Aux == 0)
                editoriales.Top_Aux = 10;
            else if (editoriales.Top_Aux == -1)
                editoriales.Top_Aux = 0;

            var editoriale = await editorialesBL.SearchAsync(editoriales);
            ViewBag.Top = editoriales.Top_Aux;

            return View(editoriale);
        }

        // GET: EditorialesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditorialesController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: EditorialesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Editoriales editoriales)
        {
            try
            {
                int result = await editorialesBL.CreateAsync(editoriales);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(editoriales);
            }
        }

        // GET: EditorialesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var editoriales = await editorialesBL.GetByIdAsync(new Editoriales { Id = id });
            return View(editoriales);
        }

        // POST: EditorialesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Editoriales editoriales)
        {
            try
            {
                int result = await editorialesBL.UpdateAsync(editoriales);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(editoriales);
            }
        }

        // GET: EditorialesController/Delete/5
        public async  Task<IActionResult> Delete(int id)
        {
            var editoriales = await editorialesBL.GetByIdAsync(new Editoriales { Id = id });
            return View(editoriales);
        }

        // POST: EditorialesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(int id, Editoriales editoriales)
        {
            try
            {
                int result = await editorialesBL.DeleteAsync(editoriales);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(editoriales);
            }
        }
    }
}
