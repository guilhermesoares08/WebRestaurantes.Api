namespace WebRestaurantes.Domain
{
    public class SchedulingOrder
    {
        int MyHour { get; set; }
        int? OrderCount { get; set; }

        int? RestaurantId { get; set; }
    }
}