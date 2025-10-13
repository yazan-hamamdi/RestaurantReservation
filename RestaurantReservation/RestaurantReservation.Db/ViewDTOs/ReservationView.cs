namespace RestaurantReservation.Db.ViewDTOs
{
    public class ReservationView
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
    }

}
