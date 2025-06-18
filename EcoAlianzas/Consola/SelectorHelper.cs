using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace EcoAlianzas.Consola
{
    public static class SelectorHelper
    {
        public static T SeleccionarElementoDeLista<T>(List<T> lista, Func<T, string> mostrarTexto)
        {
            Console.WriteLine("0. Cancelar");

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mostrarTexto(lista[i])}");
            }

            int opcion;
            do
            {
                Console.Write("Seleccione una opción: ");
            }
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > lista.Count);

            if (opcion == 0)
                return default(T);

            return lista[opcion - 1];
        }
    }
}

