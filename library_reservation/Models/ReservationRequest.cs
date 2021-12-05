namespace library_reservation.Models
{
    public class ReservationRequest
    {
        public int Id { get; set; }
        
        public ReservationRequestStatusEnum Status { get; set; }
        
        public int ReservationId { get; set;}

        public Reservation Reservation { get; set;}
    }
}
