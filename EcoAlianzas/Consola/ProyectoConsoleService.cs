using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;

namespace EcoAlianzas.Consola
{
    public static class ProyectoConsoleService
    {
        public static void CrearProyecto(ProyectoService proyectoService)
        {
            Console.WriteLine("\n=== CREAR PROYECTO ===");

            Console.Write("Ingrese nombre del proyecto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese categoría: ");
            string categoria = Console.ReadLine();

            Proyecto proyecto = new Proyecto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Categoria = categoria
            };

            proyectoService.CrearProyecto(proyecto);
            Console.WriteLine("✅ Proyecto creado correctamente.");
        }
    }
}
