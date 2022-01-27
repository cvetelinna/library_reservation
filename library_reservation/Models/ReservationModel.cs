    using library_reservation.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_reservation.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
        public string Organizers { get; set; }

        [StringLength(250, ErrorMessage = "Description should be less than 250 symbols")]
        public string Description { get; set; }
        
        public bool RequiresMultimedia { get; set; }

        public bool IsRecurring { get; set; }

        public int? RecurringSettingsId { get; set; }

        public virtual RecurringSettings RecurringSettings { get; set; }
        public virtual Hall Hall { get; set; }
    }

    public class RecurringSettings
    {
        public int Id { get; set; }

        public RecurringTypeEnum RecurrenceType { get; set; }

        public string RecurringDays { get; set; }

        public string RecurrinMonths { get; set; }

        public EndTypeEnum EndType { get; set; }

        public int? EndCounter { get; set; }

        public DateTime? RecurrenceEndDate { get; set; }
        
        public int ReservationId { get; set; }
        
        public ReservationModel Reservation { get; set; }
    }
}
