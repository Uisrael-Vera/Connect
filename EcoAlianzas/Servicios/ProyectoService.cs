using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;

namespace EcoAlianzas.Servicios
{
    public class ProyectoService
    {
        public List<Proyecto> Proyectos { get; private set; } = new List<Proyecto>();

        public void CrearProyecto(Proyecto proyecto)
        {
            Proyectos.Add(proyecto);
            Console.WriteLine($"Proyecto {proyecto.Nombre} creado exitosamente.");
        }

        public Proyecto BuscarProyectoPorNombre(string nombre)
        {
            return Proyectos.FirstOrDefault(p => p.Nombre == nombre);
        }
    }
}
