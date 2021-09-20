namespace WebRestaurantes.Domain
{
    public class Domain
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
        public Domain()
        {
            this.IsActive = true;
        }
    }
}