namespace Biwares.Cuestionario.Fagner._3
{
    public interface IAvailabilityRepository
    {
        List<AvailabilityVO> List(SearchParamsVO searchParams);
        void Delete(List<AvailabilityVO> availabilities);
        void Insert(AvailabilityVO availability);
    }
}
