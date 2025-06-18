using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;

namespace EcoAlianzas.Consola
{
    public static class SolicitudConsoleService
    {
        public static void EnviarSolicitud(ActorService actorService, ProyectoService proyectoService, Queue<SolicitudColaboracion> solicitudes)
        {
            Console.WriteLine("\n=== ENVIAR SOLICITUD DE COLABORACIÓN ===");

            if (actorService.Actores.Count == 0)
            {
                Console.WriteLine("No hay actores registrados.");
                return;
            }

            var solicitante = SelectorHelper.SeleccionarElementoDeLista(actorService.Actores, a => $"{a.Nombre} ({a.Tipo})");
            if (solicitante == null)
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }


            if (proyectoService.Proyectos.Count == 0)
            {
                Console.WriteLine("No hay proyectos registrados.");
                return;
            }

            var proyecto = SelectorHelper.SeleccionarElementoDeLista(proyectoService.Proyectos, p => $"{p.Nombre} - {p.Categoria}");
            if (proyecto == null)
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }


            solicitudes.Enqueue(new SolicitudColaboracion { Solicitante = solicitante, Proyecto = proyecto });
            Console.WriteLine("✅ Solicitud enviada.");
        }

        public static void ProcesarSolicitudes(Queue<SolicitudColaboracion> solicitudes)
        {
            if (solicitudes.Count == 0)
            {
                Console.WriteLine("No hay solicitudes pendientes.");
                return;
            }

            while (solicitudes.Count > 0)
            {
                var solicitud = solicitudes.Dequeue();
                Console.WriteLine($"\nSolicitud de {solicitud.Solicitante.Nombre} para el proyecto {solicitud.Proyecto.Nombre}");
                Console.Write("Aceptar (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();

                if (respuesta == "S")
                {
                    solicitud.Estado = EstadoSolicitud.Aceptada;
                    solicitud.Proyecto.Participantes.Add(solicitud.Solicitante);
                    Console.WriteLine("✅ Solicitud aceptada.");
                }
                else
                {
                    solicitud.Estado = EstadoSolicitud.Rechazada;
                    Console.WriteLine("❌ Solicitud rechazada.");
                }
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
