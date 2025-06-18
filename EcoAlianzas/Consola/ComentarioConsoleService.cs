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
    public static class ComentarioConsoleService
    {
        public static void ComentarProyecto(ActorService actorService, ProyectoService proyectoService)
        {
            Console.WriteLine("\n=== COMENTAR PROYECTO ===");

            var ciudadanos = actorService.Actores.OfType<Ciudadano>().ToList();
            if (ciudadanos.Count == 0)
            {
                Console.WriteLine("No hay ciudadanos registrados.");
                return;
            }

            var ciudadano = SeleccionarElementoDeLista(ciudadanos, c => c.Nombre);

            if (proyectoService.Proyectos.Count == 0)
            {
                Console.WriteLine("No hay proyectos registrados.");
                return;
            }

            var proyecto = SelectorHelper.SeleccionarElementoDeLista(proyectoService.Proyectos, p => p.Nombre);
            if (proyecto == null)
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }


            Console.Write("Ingrese el comentario: ");
            string comentario = Console.ReadLine();

            proyecto.Comentar(ciudadano, comentario);
            Console.WriteLine("✅ Comentario registrado.");
        }

        public static void VerComentariosProyecto(ProyectoService proyectoService)
        {
            Console.WriteLine("\n=== VER COMENTARIOS DE PROYECTO ===");

            if (proyectoService.Proyectos.Count == 0)
            {
                Console.WriteLine("No hay proyectos registrados.");
                return;
            }

            var proyecto = SeleccionarElementoDeLista(proyectoService.Proyectos, p => p.Nombre);

            if (proyecto.Comentarios.Count == 0)
            {
                Console.WriteLine("No hay comentarios en este proyecto.");
                return;
            }

            Console.WriteLine($"Comentarios en {proyecto.Nombre}:");
            foreach (var comentario in proyecto.Comentarios)
            {
                Console.WriteLine($"- {comentario.Autor.Nombre}: {comentario.Texto}");
            }
        }

        private static T SeleccionarElementoDeLista<T>(List<T> lista, Func<T, string> mostrarTexto)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mostrarTexto(lista[i])}");
            }

            int opcion;
            do
            {
                Console.Write("Seleccione una opción: ");
            }
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > lista.Count);

            return lista[opcion - 1];
        }
    }
}
