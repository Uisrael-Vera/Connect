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

            if (proyectoService.Proyectos.Count == 0)
            {
                Console.WriteLine("No hay proyectos disponibles para votar.");
                return;
            }

            var proyecto = SelectorHelper.SeleccionarElementoDeLista(
                proyectoService.Proyectos,
                p => $"{p.Nombre} (Votos: {p.Votantes.Count})"
            );

            if (proyecto == null)
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }

            proyecto.Votar(ciudadano);
            Console.WriteLine($"✅ Total de votos en \"{proyecto.Nombre}\": {proyecto.Votantes.Count}");
        }
    }
}
