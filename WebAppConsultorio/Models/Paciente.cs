using System;
using System.Collections.Generic;

namespace WebAppConsultorio.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            ExamenParasitologia = new HashSet<ExamenParasitologium>();
            ExamenUroanalisis = new HashSet<ExamenUroanalisi>();
        }

        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public virtual ICollection<ExamenParasitologium> ExamenParasitologia { get; set; }
        public virtual ICollection<ExamenUroanalisi> ExamenUroanalisis { get; set; }
    }
}
