using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;
using System.Collections.Generic;

namespace EcoAlianzas.Consola
{
    public static class MenuService
    {
        public static void MostrarMenu(ActorService actorService, ProyectoService proyectoService, Queue<SolicitudColaboracion> solicitudes)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n========== CONNECT+ ==========");
                Console.WriteLine("1. Registrar Actor");
                Console.WriteLine("2. Crear Proyecto");
                Console.WriteLine("3. Enviar Solicitud de Colaboración");
                Console.WriteLine("4. Procesar Solicitudes");
                Console.WriteLine("5. Ver Proyectos y Alianzas");
                Console.WriteLine("6. Votar por Proyecto");
                Console.WriteLine("7. Comentar Proyecto");
                Console.WriteLine("8. Ver Comentarios de Proyecto");
                Console.WriteLine("9. Exportar proyectos a Excel (CSV)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": ActorConsoleService.RegistrarActor(actorService); break;
                    case "2": ProyectoConsoleService.CrearProyecto(proyectoService); break;
                    case "3": SolicitudConsoleService.EnviarSolicitud(actorService, proyectoService, solicitudes); break;
                    case "4": SolicitudConsoleService.ProcesarSolicitudes(solicitudes); break;
                    case "5": ReporteConsoleService.MostrarProyectos(proyectoService); break;
                    case "6": VotacionConsoleService.VotarProyecto(actorService, proyectoService); break;
                    case "7": ComentarioConsoleService.ComentarProyecto(actorService, proyectoService); break;
                    case "8": ComentarioConsoleService.VerComentariosProyecto(proyectoService); break;
                    case "9": ExportacionConsoleService.ExportarProyectos(proyectoService); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }
        }
    }
}
