using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        [Display(Prompt="Nombre del Alumno", Name="Nombre")]
        [Required(ErrorMessage="El nombre es requerido")]
        [StringLength(30, ErrorMessage="La longitud máxima del nombre es 30")]
        public override string Nombre { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}