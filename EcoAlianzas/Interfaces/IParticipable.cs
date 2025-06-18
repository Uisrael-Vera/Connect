using EcoAlianzas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAlianzas.Interfaces
{
    public interface IParticipable
    {
        void Votar(Ciudadano ciudadano);
        void Comentar(Ciudadano autor, string comentario);
    }
}
