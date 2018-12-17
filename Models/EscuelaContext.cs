using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }
        public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogotá";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avenida Siempreviva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;            
            var cursos = CargarCursos(escuela);
            var asignaturas = CargarAsignaturas(cursos);
            var alumnos = CargarAlumnos(cursos);
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "101", Jornada = TiposJornada.Mañana, Dirección = "Avenida Siempreviva" },
                new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana, Dirección = "Avenida Siempreviva" },
                new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana, Dirección = "Avenida Siempreviva" },
                new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde, Dirección = "Avenida Siempreviva" },
                new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde, Dirección = "Avenida Siempreviva" }
            };
        }
        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> { new Asignatura { Nombre = "Matemáticas", CursoId = curso.Id, Id = Guid.NewGuid().ToString() },
                                                    new Asignatura { Nombre = "Educación Física", CursoId = curso.Id, Id = Guid.NewGuid().ToString() },
                                                    new Asignatura { Nombre = "Castellano", CursoId = curso.Id, Id = Guid.NewGuid().ToString() },
                                                    new Asignatura { Nombre = "Ciencias Naturales", CursoId = curso.Id, Id = Guid.NewGuid().ToString() },
                                                    new Asignatura { Nombre = "Programación", CursoId = curso.Id, Id = Guid.NewGuid().ToString() }
                };
                listaCompleta.AddRange(tmpList);
            }

            return listaCompleta;
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();
            Random rnd = new Random();            
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmpList = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmpList);
            }
            return listaAlumnos;
        }
        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{  CursoId = curso.Id,
                                                    Nombre = $"{n1} {n2} {a1}",
                                                    Id = Guid.NewGuid().ToString()
                                                };

            return listaAlumnos.OrderBy(al => al.Id).Take(cantidad).ToList();            
        }  
    }
}