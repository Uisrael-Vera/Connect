using EcoAlianzas.Consola;
using EcoAlianzas.Servicios;
using EcoAlianzas.Modelos;
using System.Collections.Generic;

namespace EcoAlianzas
{
    class Program
    {
        public static ActorService actorService = new ActorService();
        public static ProyectoService proyectoService = new ProyectoService();
        public static Queue<SolicitudColaboracion> solicitudes = new Queue<SolicitudColaboracion>();

        static void Main(string[] args)
        {
            InicializadorDatos.CargarDatos(actorService, proyectoService);
            MenuService.MostrarMenu(actorService, proyectoService, solicitudes);
        }
    }
}
