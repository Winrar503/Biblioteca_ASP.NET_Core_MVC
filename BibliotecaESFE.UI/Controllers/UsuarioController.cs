using BibliotecaESFE.BL;
using BibliotecaESFE.EN;
using Firebase.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BibliotecaESFE.UI.Controllers
{
   //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class UsuarioController : Controller
    { // instancias de acceso a las clases BL
        UsuarioBL usuarioBL = new UsuarioBL();
        RoleBL roleBL = new RoleBL();

        // acción que muestra el listado de registros
        public async Task<IActionResult> Index(Usuarios usuarios = null)
        {
            if (usuarios == null)
                usuarios = new Usuarios();
            if (usuarios.Top_Aux == 0)
                usuarios.Top_Aux = 10; // setear la cantidad de registros a mostrar predeterminadamente
            else if (usuarios.Top_Aux == -1)
                usuarios.Top_Aux = 0;

            var users = await usuarioBL.SearchIncludeRoleAsync(usuarios);
            ViewBag.Top = usuarios.Top_Aux;
            ViewBag.Roles = await roleBL.GetAllAsync();
            return View(users);
        }

        // acción que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var usuarios = await usuarioBL.GetByIdAsync(new Usuarios { Id = id });
            usuarios.Role = await roleBL.GetByIdAsync(new Role { Id = usuarios.IdRole });
            return View(usuarios);
        }

        // acción que muestra el formulario para agregar un nuevo registro
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await roleBL.GetAllAsync();
            ViewBag.Error = "";
            return View();
        }

        // acción que recibe los datos del formulario y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuarios usuarios)
        {
            try
            {
                int result = await usuarioBL.CreateAsync(usuarios);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await roleBL.GetAllAsync();
                return View(usuarios);
            }
        }

        // acción que muestra los datos cargados en el formulario para modificar
        public async Task<IActionResult> Edit(int id)
        {
            var userDb = await usuarioBL.GetByIdAsync(new Usuarios { Id = id });
            ViewBag.Roles = await roleBL.GetAllAsync();
            ViewBag.Error = "";
            return View(userDb);
        }

        // acción que recibe los datos modificados y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuarios usuarios)
        {
            try
            {
                int result = await usuarioBL.UpdateAsync(usuarios);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await roleBL.GetAllAsync();
                return View(usuarios);
            }
        }

        // acción que muestra los datos para confirmar la eliminación
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await usuarioBL.GetByIdAsync(new Usuarios { Id = id });
            usuario.Role = await roleBL.GetByIdAsync(new Role { Id = usuario.IdRole });
            ViewBag.Error = "";
            return View(usuario);
        }

        // acción que recibe la confirmación y elimina los datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Usuarios usuarios)
        {
            try
            {
                int result = await usuarioBL.DeleteAsync(usuarios);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var usuariosDb = await usuarioBL.GetByIdAsync(usuarios);
                if (usuariosDb == null)
                    usuariosDb = new Usuarios();
                if (usuariosDb.Id > 0)
                    usuariosDb.Role = await roleBL.GetByIdAsync(new Role { Id = usuariosDb.IdRole });
                return View(usuariosDb);
            }
        }

        // acción que muestra el formulario de inicio de sesión
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Url = returnUrl;
            ViewBag.Error = "";
            return View();
        }

        // acción que recibe los datos de inicio de sesión y ejecuta la autenticación
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuarios usuarios, string returnUrl = null)
        {
            try
            {
                var usuarioDb = await usuarioBL.LoginAsync(usuarios);
                if (usuarioDb != null && usuarioDb.Id > 0 && usuarioDb.Login == usuarios.Login)
                {
                    usuarioDb.Role = await roleBL.GetByIdAsync(new Role { Id = usuarioDb.IdRole });
                    var claims = new[] {new Claim(ClaimTypes.Name, usuarioDb.Login),
                                new Claim(ClaimTypes.Role, usuarioDb.Role.Name)};
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                }
                else
                    throw new Exception("Credenciales de usuario incorrectas");

                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Url = returnUrl;
                ViewBag.Error = ex.Message;
                return View(new Usuarios { Login = usuarios.Login });
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Usuario");
        }

        //acción que muestra el formulario para cambiar contraseña
        public async Task<IActionResult> ChangePassword()
        {
            var usuario = await usuarioBL.SearchAsync(new Usuarios { Login = User.Identity.Name, Top_Aux = 1 });
            var actualUser = usuario.FirstOrDefault();
            ViewBag.Error = "";
            return View(actualUser);
        }

        //acción que recibe los datos de la nueva contraseña
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(Usuarios usuarios, string oldPassword)
        {
            try
            {
                int result = await usuarioBL.ChangePasswordAsync(usuarios, oldPassword);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var users = await usuarioBL.SearchAsync(new Usuarios { Login = User.Identity.Name, Top_Aux = 1 });
                var actualUser = users.FirstOrDefault();
                return View(actualUser);
            }
        }
    }
}
