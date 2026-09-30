using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchedulerGSync.DAL {
    public class AppointmentObject {
        
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Subject { get; set; }
        public int AppointmentType { get; set; }
        public string RecurrenceInfo { get; set; }
        public string ReminderInfo { get; set; }
        public string Location { get; set; }
        public string Label { get; set; }
        public string GId { get; set; }
        public string ETag { get; set; }
    }
}
