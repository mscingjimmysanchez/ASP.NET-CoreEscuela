using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Display(Prompt="Nombre del Curso", Name="Nombre")]
        [Required(ErrorMessage="El nombre es requerido")]
        [StringLength(10, ErrorMessage="La longitud máxima del nombre es 10")]
        public override string Nombre { get; set; }
        [Display(Prompt="Jornada del Curso", Name="Jornada")]
        [Required(ErrorMessage="La jornada es requerida")]
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        [Display(Prompt="Dirección del Curso", Name="Dirección")]
        [Required(ErrorMessage="La dirección es requerida")]
        [MinLength(10, ErrorMessage="La longitud mínima de la dirección es 10")]
        public string Dirección { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}