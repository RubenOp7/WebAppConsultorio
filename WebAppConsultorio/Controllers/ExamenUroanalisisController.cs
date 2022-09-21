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
    public class ExamenUroanalisisController : Controller
    {
        private readonly ConsultorioContext _context;

        public ExamenUroanalisisController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: ExamenUroanalisis
        public async Task<IActionResult> Index()
        {
            //var query = from ExamenUroanalise in _context.ExamenUroanalises
            //            join paciente in _context.Pacientes on ExamenUroanalise.IdPaciente equals paciente.IdPaciente
            //            join doc in _context.Doctors on ExamenUroanalise.IdDoctor equals doc.IdDoctor
            //            select new
            //            {
            //                nombrePaciente = paciente.Nombre,
            //                nombreDoctor = doc.Nombre,
            //                examen = ExamenUroanalise.Reaccion
            //            };

            //foreach(var obj in query)
            //{
            //    Console.WriteLine(obj.examen + obj.nombrePaciente + obj.nombreDoctor);
            //}




            var consultorioContext = _context.ExamenUroanalises.Include(e => e.IdDoctorNavigation).Include(e => e.IdPacienteNavigation);
            return View(await consultorioContext.ToListAsync());
        }

        // GET: ExamenUroanalisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamenUroanalises == null)
            {
                return NotFound();
            }

            var examenUroanalisi = await _context.ExamenUroanalises
                .Include(e => e.IdDoctorNavigation)
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdExamenUro == id);
            if (examenUroanalisi == null)
            {
                return NotFound();
            }

            return View(examenUroanalisi);
        }

        // GET: ExamenUroanalisis/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: ExamenUroanalisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExamenUro,IdPaciente,IdDoctor,Fecha,Color,Olor,Aspecto,Sedimento,GravedadEspecifica,Reaccion,Ph,SustanciasProteicas,SustanciasReductoras,SangreOculta,CuerposCetonicos,Acascorbico,Urobilinogeno,Bilirrubinas,Nitritos,Cilindros,Leucocitos480,LeucocitosGrumos,Entrocitos480,CelulasEpiteliales")] ExamenUroanalisi examenUroanalisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examenUroanalisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor", examenUroanalisi.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", examenUroanalisi.IdPaciente);
            return View(examenUroanalisi);
        }

        // GET: ExamenUroanalisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamenUroanalises == null)
            {
                return NotFound();
            }

            var examenUroanalisi = await _context.ExamenUroanalises.FindAsync(id);
            if (examenUroanalisi == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor", examenUroanalisi.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", examenUroanalisi.IdPaciente);
            return View(examenUroanalisi);
        }

        // POST: ExamenUroanalisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExamenUro,IdPaciente,IdDoctor,Fecha,Color,Olor,Aspecto,Sedimento,GravedadEspecifica,Reaccion,Ph,SustanciasProteicas,SustanciasReductoras,SangreOculta,CuerposCetonicos,Acascorbico,Urobilinogeno,Bilirrubinas,Nitritos,Cilindros,Leucocitos480,LeucocitosGrumos,Entrocitos480,CelulasEpiteliales")] ExamenUroanalisi examenUroanalisi)
        {
            if (id != examenUroanalisi.IdExamenUro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examenUroanalisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamenUroanalisiExists(examenUroanalisi.IdExamenUro))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctors, "IdDoctor", "IdDoctor", examenUroanalisi.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", examenUroanalisi.IdPaciente);
            return View(examenUroanalisi);
        }

        // GET: ExamenUroanalisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamenUroanalises == null)
            {
                return NotFound();
            }

            var examenUroanalisi = await _context.ExamenUroanalises
                .Include(e => e.IdDoctorNavigation)
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdExamenUro == id);
            if (examenUroanalisi == null)
            {
                return NotFound();
            }

            return View(examenUroanalisi);
        }

        // POST: ExamenUroanalisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamenUroanalises == null)
            {
                return Problem("Entity set 'ConsultorioContext.ExamenUroanalises'  is null.");
            }
            var examenUroanalisi = await _context.ExamenUroanalises.FindAsync(id);
            if (examenUroanalisi != null)
            {
                _context.ExamenUroanalises.Remove(examenUroanalisi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamenUroanalisiExists(int id)
        {
          return (_context.ExamenUroanalises?.Any(e => e.IdExamenUro == id)).GetValueOrDefault();
        }
    }
}
