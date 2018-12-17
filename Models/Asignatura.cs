using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        [Display(Prompt="Nombre de la Asignatura", Name="Nombre")]
        [Required(ErrorMessage="El nombre es requerido")]
        [StringLength(20, ErrorMessage="La longitud máxima del nombre es 20")]
        public override string Nombre { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}