namespace Biwares.Cuestionario.Fagner._3
{
    /// <summary>
    /// Clase de servicio para gestionar la disponibilidad de los empleados.
    /// Refactorizada para mejorar la legibilidad y mantenibilidad.
    /// </summary>
    public class AvailabilityService
    {
        /// <summary>
        /// Inserta la disponibilidad de un empleado después de eliminar las antiguas.
        /// </summary>
        /// <param name="employeeId">ID del empleado</param>
        /// <param name="availabilityList">Lista de disponibilidades nuevas</param>
        /// <param name="companyId">ID de la empresa</param>
        public void InsertarDisponibilidad(int employeeId, List<AvailabilityDTO> availabilityList, int companyId)
        {
            try
            {
                var searchParams = ConstruirParametrosBusqueda(employeeId, companyId);

                ValidarDisponibilidad(availabilityList);

                EliminarDisponibilidadesAnteriores(searchParams);

                InsertarDisponibilidades(availabilityList, employeeId, companyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private SearchParamsVO ConstruirParametrosBusqueda(int employeeId, int companyId)
        {
            return new SearchParamsVO
            {
                EmployeeId = employeeId,
                CompanyId = companyId,
                Type = "HOURS"
            };
        }

        private void EliminarDisponibilidadesAnteriores(SearchParamsVO parametrosBusqueda)
        {
            var disponibilidadesAEliminar = availabilityRepository.List(parametrosBusqueda);
            if (disponibilidadesAEliminar.Any())
            {
                availabilityRepository.Delete(disponibilidadesAEliminar);
            }
        }

        private void InsertarDisponibilidades(List<AvailabilityDTO> disponibilidades, int employeeId, int companyId)
        {
            foreach (var disponibilidad in disponibilidades)
            {
                var nuevaDisponibilidad = new AvailabilityVO
                {
                    StartTime = disponibilidad.StartTime,
                    EndTime = disponibilidad.EndTime,
                    DayOfWeek = disponibilidad.DayOfWeek,
                    EmployeeId = employeeId,
                    CompanyId = companyId,
                    Type = "HOURS"
                };

                availabilityRepository.Insert(nuevaDisponibilidad);
            }
        }

        private void ValidarDisponibilidad(List<AvailabilityDTO> disponibilidades)
        {
            if (disponibilidades == null || !disponibilidades.Any())
            {
                throw new ArgumentException("La lista de disponibilidades no puede estar vacía.");
            }
        }

        private readonly IAvailabilityRepository availabilityRepository = new FakeAvailabilityRepository();
    }
}
