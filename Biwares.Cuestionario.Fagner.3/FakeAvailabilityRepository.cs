namespace Biwares.Cuestionario.Fagner._3
{
    public class FakeAvailabilityRepository : IAvailabilityRepository
    {
        public List<AvailabilityVO> List(SearchParamsVO searchParams) => new();
        public void Delete(List<AvailabilityVO> availabilities) => Console.WriteLine("Disponibilidades eliminadas.");
        public void Insert(AvailabilityVO availability) => Console.WriteLine("Disponibilidad insertada.");
    }
}
