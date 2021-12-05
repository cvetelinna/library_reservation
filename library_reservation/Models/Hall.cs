using System.Collections.Generic;

namespace library_reservation.Models
{
    public class Hall
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public HallTypeEnum Type { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
