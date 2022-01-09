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

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Subject { get; set; }

        public string Organizers { get; set; }

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
