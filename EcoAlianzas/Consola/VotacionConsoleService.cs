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
    public static class VotacionConsoleService
    {
        public static void VotarProyecto(ActorService actorService, ProyectoService proyectoService)
        {
            Console.WriteLine("\n=== VOTAR PROYECTO ===");

            var ciudadanos = actorService.Actores.OfType<Ciudadano>().ToList();
            if (ciudadanos.Count == 0)
            {
                Console.WriteLine("No hay ciudadanos registrados.");
                return;
            }

            var ciudadano = SelectorHelper.SeleccionarElementoDeLista(ciudadanos, c => c.Nombre);
            if (ciudadano == null)
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }


            var proyecto = SelectorHelper.SeleccionarElementoDeLista(proyectoService.Proyectos, p => $"{p.Nombre} (Votos: {p.Votantes.Count})");
            if (proyecto == null)
            {
                Console.WriteLine("Operación cancelada.");
                return;
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

