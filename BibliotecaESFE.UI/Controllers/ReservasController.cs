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
    public class ReservasController : Controller
    {
        ReservasBL reservasBL = new ReservasBL();
        UsuarioBL usuarioBL = new UsuarioBL();
        LibrosBL librosBL = new LibrosBL();


        // GET: ReservasController
        public async Task<IActionResult> Index(Reservas reservas = null)
        {
            if (reservas == null)
                reservas = new Reservas();
            if (reservas.Top_Aux == 0)
                reservas.Top_Aux = 0;
            else if (reservas.Top_Aux == -1)
                reservas.Top_Aux = 0;

            var reserva = await reservasBL.SearchIncludeReservasAsync(reservas);
            ViewBag.Top = reservas.Top_Aux;

            var usuarios = await usuarioBL.GetAllAsync();
            var libros = await librosBL.GetAllAsync();


            ViewBag.Usuarios = usuarios;
            ViewBag.Libros = libros;

            return View(reserva);
        }
        // GET: ReservasController/IndexUs
        public async Task<IActionResult> IndexUs()
        {
            var reservas = await reservasBL.GetAllAsync();
            // Cargar los usuarios y libros relacionados
            foreach (var reserva in reservas)
            {
                reserva.Usuarios = await usuarioBL.GetByIdAsync(new Usuarios { Id = reserva.UsuarioId });
                reserva.Libros = await librosBL.GetByIdAsync(new Libros { Id = reserva.LibroId });
            }
            return View(reservas);
        }


        // GET: ReservasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reservas = await reservasBL.GetByIdAsync(new Reservas { Id = id });
            reservas.Usuarios = await usuarioBL.GetByIdAsync(new Usuarios { Id = reservas.UsuarioId });
            reservas.Libros = await librosBL.GetByIdAsync(new Libros { Id = reservas.LibroId });
            return View(reservas);
        }

        // GET: ReservasController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Usuarios = await usuarioBL.GetAllAsync();
            ViewBag.Libros = await librosBL.GetAllAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservas reservas)
        {
            try
            {
                int result = await reservasBL.CreateAsync(reservas);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuarios = await usuarioBL.GetAllAsync();
                ViewBag.Libros = await librosBL.GetAllAsync();
                return View(reservas);
            }
        }

        // GET: ReservasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var reservasDb = await reservasBL.GetByIdAsync(new Reservas { Id = id });
            ViewBag.Usuarios = await usuarioBL.GetAllAsync();
            ViewBag.Libros = await librosBL.GetAllAsync();
            return View(reservasDb);
        }

        // POST: ReservasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservas reservas)
        {
            try
            {
                int result = await reservasBL.UpdateAsync(reservas);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuarios = await usuarioBL.GetAllAsync();
                ViewBag.Libros = await librosBL.GetAllAsync();
                return View(reservas);
            }
        }

        // GET: ReservasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var reservas = await reservasBL.GetByIdAsync(new Reservas { Id = id });
            reservas.Usuarios = await usuarioBL.GetByIdAsync(new Usuarios { Id = reservas.UsuarioId });
            reservas.Libros = await librosBL.GetByIdAsync(new Libros { Id = reservas.LibroId });
            ViewBag.Error = "";
            return View(reservas);
        }

        // POST: ReservasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Reservas reservas)
        {
            try
            {
                int result = await reservasBL.DeleteAsync(reservas);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var reservasDb = await reservasBL.GetByIdAsync(reservas);
                if (reservasDb == null)
                    reservasDb = new Reservas();
                if (reservasDb.Id > 0)
                    reservasDb.Usuarios = await usuarioBL.GetByIdAsync(new Usuarios { Id = reservasDb.UsuarioId });
                if (reservasDb.Id > 0)
                    reservasDb.Libros = await librosBL.GetByIdAsync(new Libros { Id = reservasDb.LibroId });

                return View(reservasDb);
            }
        }
    }
}
