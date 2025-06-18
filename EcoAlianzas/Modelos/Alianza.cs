using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAlianzas.Modelos
{
    public class Alianza
    {
        public Proyecto Proyecto { get; set; }
        public List<Actor> Participantes { get; set; }
    }
}
