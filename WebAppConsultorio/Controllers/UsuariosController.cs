using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppConsultorio.Models;

namespace WebAppConsultorio.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ConsultorioContext _context;

        public UsuariosController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: Acceso
        public async Task<ActionResult> LoginAsync()
        {
            ServiceReference1.Tipo_Cambio_BCNSoapClient Cliente = new ServiceReference1.Tipo_Cambio_BCNSoapClient(ServiceReference1.Tipo_Cambio_BCNSoapClient.EndpointConfiguration.Tipo_Cambio_BCNSoap);
            ServiceReference1.RecuperaTC_DiaRequest DiaReq = new ServiceReference1.RecuperaTC_DiaRequest(2022, 10, 01);
            var response = await Cliente.RecuperaTC_DiaAsync(DiaReq);
            Console.WriteLine(response);
            ViewData["TCDIA"] = string.Concat("Primero de Octubre: ", response.RecuperaTC_DiaResult);
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario user)
        {

            if(user.Contrasena == null || user.Usuario1 == null)
            {
                ViewData["Mensaje"] = "Llenar todos los campos";
                return PartialView();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var result = await _context.Usuarios.FromSqlRaw("Sp_ValidarUsuario {0},{1}", user.Usuario1, user.Contrasena).ToListAsync();
                    if (result.Count > 0)
                    {
                        return RedirectToAction("Index", "Usuarios");
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Usuario no encontrado";
                        return PartialView();

                    }

                }
                return PartialView();
            }

        }
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Usuarios != null ? 
                          View(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'ConsultorioContext.Usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Usuario1,Contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Usuario1,Contrasena")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ConsultorioContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
