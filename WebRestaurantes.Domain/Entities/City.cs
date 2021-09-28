namespace WebRestaurantes.Domain
{
    public class City
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }
    }
}