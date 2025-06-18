using EcoAlianzas.Modelos;
using EcoAlianzas.Servicios;
using System.IO;

namespace EcoAlianzas.Consola
{
    public static class ExportacionConsoleService
    {
        public static void ExportarProyectos(ProyectoService proyectoService)
        {
            string rutaBase = Directory.GetCurrentDirectory();
            string rutaReportes = Path.Combine(rutaBase, "Reportes");

            if (!Directory.Exists(rutaReportes))
                Directory.CreateDirectory(rutaReportes);

            string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nombreArchivo = $"proyectos_{fechaHora}.csv";
            string rutaArchivo = Path.Combine(rutaReportes, nombreArchivo);

            try
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo, false, new System.Text.UTF8Encoding(true)))
                {
                    writer.WriteLine("Nombre,Descripción,Categoría,Votos,Comentarios,TotalParticipantes");

                    foreach (var proyecto in proyectoService.Proyectos)
                    {
                        writer.WriteLine($"{proyecto.Nombre},{proyecto.Descripcion},{proyecto.Categoria},{proyecto.Votantes.Count},{proyecto.Comentarios.Count},{proyecto.Participantes.Count}");
                    }
                }

                Console.WriteLine($"\n✅ Archivo generado correctamente: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al generar el archivo: {ex.Message}");
            }
        }
    }
}
