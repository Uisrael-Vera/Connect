using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;

namespace EcoAlianzas.Servicios
{
    public class ActorService
    {
        public List<Actor> Actores { get; private set; } = new List<Actor>();

        public void RegistrarActor(Actor actor)
        {
            Actores.Add(actor);
            Console.WriteLine($"Actor {actor.Nombre} registrado correctamente.");
        }

        public Actor BuscarActorPorNombre(string nombre)
        {
            return Actores.FirstOrDefault(a => a.Nombre == nombre);
        }
    }
}
