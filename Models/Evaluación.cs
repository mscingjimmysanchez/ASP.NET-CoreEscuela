using System;

namespace ASP.NET_Core.Models
{
    public class Evaluación:ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public string AlumnoId { get; set; }
        public Asignatura Asignatura  { get; set; }
        public string AsignaturaId  { get; set; }
        public float Nota { get; set; }
    }
}