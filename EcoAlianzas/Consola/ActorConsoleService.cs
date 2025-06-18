using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;

namespace EcoAlianzas.Consola
{
    public static class ActorConsoleService
    {
        public static void RegistrarActor(ActorService actorService)
        {
            Console.WriteLine("\n=== REGISTRAR ACTOR ===");

            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Seleccione tipo de actor:");
            Console.WriteLine("1. Ciudadano");
            Console.WriteLine("2. ONG");
            Console.WriteLine("3. Gobierno");
            string tipoOpcion = Console.ReadLine();

            Actor nuevoActor = tipoOpcion switch
            {
                "1" => new Ciudadano { Nombre = nombre, Email = email, Tipo = "Ciudadano" },
                "2" => new ONG { Nombre = nombre, Email = email, Tipo = "ONG" },
                "3" => new Gobierno { Nombre = nombre, Email = email, Tipo = "Gobierno" },
                _ => null
            };

            if (nuevoActor == null)
                Console.WriteLine("Tipo inválido.");
            else
            {
                actorService.RegistrarActor(nuevoActor);
                Console.WriteLine("✅ Actor registrado correctamente.");
            }
        }
    }
}
