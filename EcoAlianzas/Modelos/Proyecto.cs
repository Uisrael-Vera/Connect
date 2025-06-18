using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Interfaces;

namespace EcoAlianzas.Modelos
{
    public class Proyecto : IParticipable, ISeguible
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public List<Actor> Participantes { get; set; } = new List<Actor>();
        public List<Ciudadano> Votantes { get; set; } = new List<Ciudadano>();
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public List<Ciudadano> Seguidores { get; set; } = new List<Ciudadano>();

        public void Votar(Ciudadano ciudadano)
        {
            if (Votantes.Any(c => c.Email == ciudadano.Email))
            {
                Console.WriteLine("⚠ Ya votaste por este proyecto.");
            }
            else
            {
                Votantes.Add(ciudadano);
                Console.WriteLine("✅ ¡Voto registrado!");
            }
        }


        public void Comentar(Ciudadano autor, string comentario)
        {
            Comentarios.Add(new Comentario { Autor = autor, Texto = comentario });
        }

        public void Seguir(Ciudadano ciudadano)
        {
            if (!Seguidores.Contains(ciudadano))
                Seguidores.Add(ciudadano);
        }
    }
}
