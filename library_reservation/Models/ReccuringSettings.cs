using System;
using System.Collections.Generic;

namespace library_reservation.Models
{
    public class RecurringSettings
    {
      
        public ReccuringTypeEnum RecurrenceType { get; set; }

        public List<DaysEnum> ReccuringDays { get; set; }

        public List<MonthsEnum> ReccuringMonths { get; set; }

        public DateTime StartDate { get; set; }

        public EndTypEnum EndType { get; set; }

        public int EndCounter { get; set; }

        public DateTime EndDate { get; set; }

    }
}
