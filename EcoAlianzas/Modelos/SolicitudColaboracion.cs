using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAlianzas.Modelos
{
    public enum EstadoSolicitud
    {
        Pendiente,
        Aceptada,
        Rechazada
    }

    public class SolicitudColaboracion
    {
        public Actor Solicitante { get; set; }
        public Proyecto Proyecto { get; set; }
        public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;
    }
}
