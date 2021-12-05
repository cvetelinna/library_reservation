namespace library_reservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public int ReservationRequestId { get; set; }
        
        public Hall Hall { get; set; }

        public ReservationRequest ReservationRequest { get; set; }
    }
}
