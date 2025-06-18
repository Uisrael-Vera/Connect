using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;

namespace EcoAlianzas.Consola
{
    public static class InicializadorDatos
    {
        public static void CargarDatos(ActorService actorService, ProyectoService proyectoService)
        {
            // Precargar Ciudadanos
            actorService.RegistrarActor(new Ciudadano { Nombre = "Juan Pérez", Email = "juan@correo.com", Tipo = "Ciudadano" });
            actorService.RegistrarActor(new Ciudadano { Nombre = "María Gómez", Email = "maria@correo.com", Tipo = "Ciudadano" });
            actorService.RegistrarActor(new Ciudadano { Nombre = "Pedro López", Email = "pedro@correo.com", Tipo = "Ciudadano" });
            actorService.RegistrarActor(new Ciudadano { Nombre = "Ana Torres", Email = "ana@correo.com", Tipo = "Ciudadano" });

            // Precargar ONGs
            actorService.RegistrarActor(new ONG { Nombre = "EcoVerde ONG", Email = "ecoverde@ong.com", Tipo = "ONG" });
            actorService.RegistrarActor(new ONG { Nombre = "Fundación Futuro Sostenible", Email = "futuro@ong.com", Tipo = "ONG" });
            actorService.RegistrarActor(new ONG { Nombre = "Aire Limpio ONG", Email = "airelimpio@ong.com", Tipo = "ONG" });

            // Precargar Gobiernos
            actorService.RegistrarActor(new Gobierno { Nombre = "Municipio Quito", Email = "quito@gobierno.com", Tipo = "Gobierno" });
            actorService.RegistrarActor(new Gobierno { Nombre = "Gobierno Pichincha", Email = "pichincha@gobierno.com", Tipo = "Gobierno" });
            actorService.RegistrarActor(new Gobierno { Nombre = "Ministerio de Ambiente", Email = "ambiente@gobierno.com", Tipo = "Gobierno" });

            // Precargar Proyectos
            proyectoService.CrearProyecto(new Proyecto { Nombre = "Reciclaje Urbano", Descripcion = "Mejorar el sistema de reciclaje", Categoria = "Comunitario" });
            proyectoService.CrearProyecto(new Proyecto { Nombre = "Huertos Comunitarios", Descripcion = "Promover la agricultura urbana", Categoria = "Comunitario" });
            proyectoService.CrearProyecto(new Proyecto { Nombre = "Transporte Eléctrico", Descripcion = "Renovar la flota pública de transporte", Categoria = "Movilidad" });
            proyectoService.CrearProyecto(new Proyecto { Nombre = "Energía Solar Barrial", Descripcion = "Instalación de paneles solares en los barrios", Categoria = "Energía" });
            proyectoService.CrearProyecto(new Proyecto { Nombre = "Reforestación Urbana", Descripcion = "Aumentar las áreas verdes urbanas", Categoria = "Ambiente" });
        }
    }
}

