using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppConsultorio.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Column("Usuario")]
        [StringLength(30)]
        [Unicode(false)]
        //[NotMapped]
        [Display(Name = "Usuario")]

        public string Usuario1 { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string Contrasena { get; set; } = null!;
    }
}
