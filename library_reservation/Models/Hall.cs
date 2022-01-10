using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace library_reservation.Models
{
    public class Hall
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string Name { get; set; }

        public HallTypeEnum Type { get; set; }

        public IEnumerable<ReservationModel> Reservations { get; set; }
    }
}
