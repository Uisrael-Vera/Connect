using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;
using System.Linq;

namespace EcoAlianzas.Consola
{
    public static class ReporteConsoleService
    {
        public static void MostrarProyectos(ProyectoService proyectoService)
        {
            if (proyectoService.Proyectos.Count == 0)
            {
                Console.WriteLine("\nNo hay proyectos registrados.");
                return;
            }

            Console.WriteLine("\n========== PROYECTOS Y ALIANZAS ==========");

            foreach (var proyecto in proyectoService.Proyectos)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"PROYECTO: {proyecto.Nombre}");
                Console.WriteLine($"DESCRIPCIÓN: {proyecto.Descripcion}");
                Console.WriteLine($"CATEGORÍA: {proyecto.Categoria}");
                Console.WriteLine($"VOTOS: {proyecto.Votantes.Count}");
                Console.WriteLine($"COMENTARIOS: {proyecto.Comentarios.Count}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("PARTICIPANTES:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{"NOMBRE",-20} {"TIPO",-15}");
                foreach (var actor in proyecto.Participantes)
                {
                    Console.WriteLine($"{actor.Nombre,-20} {actor.Tipo,-15}");
                }

                bool tieneCiudadano = proyecto.Participantes.OfType<Ciudadano>().Any();
                bool tieneONG = proyecto.Participantes.OfType<ONG>().Any();
                bool tieneGobierno = proyecto.Participantes.OfType<Gobierno>().Any();

                Console.WriteLine("----------------------------------------");
                if (tieneCiudadano && tieneONG && tieneGobierno)
                    Console.WriteLine("✅ ALIANZA ESTRATÉGICA FORMADA");
                else
                    Console.WriteLine("🔄 Alianza aún incompleta.");
            }
        }
    }
}

