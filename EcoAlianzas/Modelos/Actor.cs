using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAlianzas.Modelos
{
    public abstract class Actor
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}, Email: {Email}, Tipo: {Tipo}");
        }
    }
}
