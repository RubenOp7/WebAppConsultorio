using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppConsultorio.Models
{
    public partial class ExamenParasitologium
    {
        public int IdExamenParasito { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Fecha { get; set; }
        public string? Color { get; set; }
        public string? Consistencia { get; set; }
        [Display(Name = "Ascaris Lumbricoides")]
        public string? AscarisLumbricoides { get; set; }
        public string? AncylostomaDondenale { get; set; }
        public string? NecatorAmericano { get; set; }
        public string? EnterabiusVermicular { get; set; }
        public string? TrichurisTrichura { get; set; }
        public string? EntamoebaColi { get; set; }
        public string? EntamoebaHistolitica { get; set; }
        public string? GiardiaLamblia { get; set; }
        public string? TrichomonasHomunis { get; set; }
        [Display(Name = "Taenia Saguiata")]
        public string? TaeniaSaguiata { get; set; }
        [Display(Name = "Taenia Salium")]
        public string? TaeniaSalium { get; set; }
        [Display(Name = "Hymenolepis Nana")]
        public string? HymenolepisNana { get; set; }
        [Display(Name = "Hymenolepis Diminuta")]
        public string? HymenolepisDiminuta { get; set; }
        public string? Observaciones { get; set; }
        [Display(Name = "Doctor")]
        public virtual Doctor IdDoctorNavigation { get; set; } = null!;
        [Display(Name = "Paciente")]
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
    }
}
