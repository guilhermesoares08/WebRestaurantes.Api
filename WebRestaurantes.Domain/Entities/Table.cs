namespace WebRestaurantes.Domain
{
    public class Table
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int RestaurantId { get; set; }

        public int Seats { get; set; }

        public string VendorId { get; set; }       

        public bool IsActive { get; set; }

        //está ocupado?
        public bool IsBusy { get; set; }

        public Restaurant Restaurant { get; }

        public Table()
        {
            IsActive = true;
            IsBusy = false;
        }
    }
}