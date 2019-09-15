using System;

namespace App.Model
{
    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public string Title { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
    }
}
