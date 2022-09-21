using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppConsultorio.Models;

namespace WebAppConsultorio.Controllers
{
    public class ExamenParasitologiumsController : Controller
    {
        private readonly ConsultorioContext _context;

        public ExamenParasitologiumsController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: ExamenParasitologiums
        public async Task<IActionResult> Index()
        {
            var consultorioContext = _context.ExamenParasitologia.Include(e => e.IdDoctorNavigation).Include(e => e.IdPacienteNavigation);
            return View(await consultorioContext.ToListAsync());
        }

        // GET: ExamenParasitologiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamenParasitologia == null)
            {
                return NotFound();
            }

            var examenParasitologium = await _context.ExamenParasitologia
                .Include(e => e.IdDoctorNavigation)
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdExamenParasito == id);
            if (examenParasitologium == null)
            {
                return NotFound();
            }

            return View(examenParasitologium);
        }

        // GET: ExamenParasitologiums/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente");
            ViewData["Nombre"] = new SelectList(_context.Doctors, "Nombre", "Nombre");

            return View();
        }

        // POST: ExamenParasitologiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExamenParasito,IdPaciente,IdDoctor,Fecha,Color,Consistencia,AscarisLumbricoides,AncylostomaDondenale,NecatorAmericano,EnterabiusVermicular,TrichurisTrichura,EntamoebaColi,EntamoebaHistolitica,GiardiaLamblia,TrichomonasHomunis,TaeniaSaguiata,TaeniaSalium,HymenolepisNana,HymenolepisDiminuta,Observaciones")] ExamenParasitologium examenParasitologium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examenParasitologium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor", examenParasitologium.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", examenParasitologium.IdPaciente);
            return View(examenParasitologium);
        }

        // GET: ExamenParasitologiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamenParasitologia == null)
            {
                return NotFound();
            }

            var examenParasitologium = await _context.ExamenParasitologia.FindAsync(id);
            if (examenParasitologium == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor", examenParasitologium.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", examenParasitologium.IdPaciente);
            return View(examenParasitologium);
        }

        // POST: ExamenParasitologiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExamenParasito,IdPaciente,IdDoctor,Fecha,Color,Consistencia,AscarisLumbricoides,AncylostomaDondenale,NecatorAmericano,EnterabiusVermicular,TrichurisTrichura,EntamoebaColi,EntamoebaHistolitica,GiardiaLamblia,TrichomonasHomunis,TaeniaSaguiata,TaeniaSalium,HymenolepisNana,HymenolepisDiminuta,Observaciones")] ExamenParasitologium examenParasitologium)
        {
            if (id != examenParasitologium.IdExamenParasito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examenParasitologium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamenParasitologiumExists(examenParasitologium.IdExamenParasito))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor", examenParasitologium.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", examenParasitologium.IdPaciente);
            return View(examenParasitologium);
        }

        // GET: ExamenParasitologiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamenParasitologia == null)
            {
                return NotFound();
            }

            var examenParasitologium = await _context.ExamenParasitologia
                .Include(e => e.IdDoctorNavigation)
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdExamenParasito == id);
            if (examenParasitologium == null)
            {
                return NotFound();
            }

            return View(examenParasitologium);
        }

        // POST: ExamenParasitologiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamenParasitologia == null)
            {
                return Problem("Entity set 'ConsultorioContext.ExamenParasitologia'  is null.");
            }
            var examenParasitologium = await _context.ExamenParasitologia.FindAsync(id);
            if (examenParasitologium != null)
            {
                _context.ExamenParasitologia.Remove(examenParasitologium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamenParasitologiumExists(int id)
        {
          return (_context.ExamenParasitologia?.Any(e => e.IdExamenParasito == id)).GetValueOrDefault();
        }
    }
}
