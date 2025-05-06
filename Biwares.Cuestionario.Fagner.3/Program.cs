namespace Biwares.Cuestionario.Fagner._3
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Clase principal para probar el servicio de disponibilidad.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando prueba de AvailabilityService...");

            var servicio = new AvailabilityService();

            var disponibilidades = new List<AvailabilityDTO>
        {
            new AvailabilityDTO { DayOfWeek = "Lunes", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0) },
            new AvailabilityDTO { DayOfWeek = "Martes", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(18, 0, 0) }
        };

            try
            {
                servicio.InsertarDisponibilidad(1, disponibilidades, 100);
                Console.WriteLine("Prueba completada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error: {ex.Message}");
            }
        }
    }

}