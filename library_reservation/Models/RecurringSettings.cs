using System;
using System.Collections.Generic;

namespace library_reservation.Models
{
    public class RecurringSettings
    {
        public int Id { get; set; }

        public RecurringTypeEnum RecurrenceType { get; set; }

        //public List<DaysEnum> ReccuringDays { get; set; }

        //public List<MonthsEnum> ReccuringMonths { get; set; }

        public DateTime StartDate { get; set; }

        public EndTypeEnum EndType { get; set; }

        public int EndCounter { get; set; }

        public DateTime EndDate { get; set; }

    }
}
