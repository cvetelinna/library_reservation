namespace library_reservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Subject { get; set; }
        
        public string[] Organizers { get; set; }

        public string Description { get; set; }
        
        public bool RequiresMultimedia { get; set; }

        public int ReservationRequestId { get; set; }
        
        public Hall Hall { get; set; }

        public ReservationRequest ReservationRequest { get; set; }

        //To Do add user entity when Identity is done
    }
}
