using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppConsultorio.Models
{
    public partial class ExamenUroanalisi
    {
        public int IdExamenUro { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Fecha { get; set; }
        public string? Color { get; set; }
        public string? Olor { get; set; }
        public string? Aspecto { get; set; }
        public string? Sedimento { get; set; }
        [Display(Name = "Gravedad Especifica")]
        public string? GravedadEspecifica { get; set; }
        public string? Reaccion { get; set; }
        public decimal? Ph { get; set; }
        [Display(Name = "Sustancias Proteicas")]
        public string? SustanciasProteicas { get; set; }
        [Display(Name = "Sustancias Reductoras")]
        public string? SustanciasReductoras { get; set; }
        [Display(Name = "Sangre Oculta")]
        public string? SangreOculta { get; set; }
        [Display(Name = "Cuerpos Cetonicos")]
        public string? CuerposCetonicos { get; set; }
        public string? Acascorbico { get; set; }
        public string? Urobilinogeno { get; set; }
        public string? Bilirrubinas { get; set; }
        public string? Nitritos { get; set; }
        public string? Cilindros { get; set; }
        [Display(Name = "Leucocitos 480")]
        public string? Leucocitos480 { get; set; }
        [Display(Name = "Leucocitos Grumos")]
        public string? LeucocitosGrumos { get; set; }
        [Display(Name = "Entrocitos 480")]
        public string? Entrocitos480 { get; set; }
        [Display(Name = "Celulas Epiteliales")]
        public string? CelulasEpiteliales { get; set; }
        [Display(Name = "Doctor")]
        public virtual Doctor IdDoctorNavigation { get; set; } = null!;
        [Display(Name = "Paciente")]
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
    }
}
