using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerGSync.DAL {
    public class SchedulerGSyncDbContext : DbContext {
        public static readonly string DBFileName = $"{nameof(SchedulerGSync)}.sqlite";

        public DbSet<AppointmentObject> AppointmentObjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite($"Filename={DBFileName}");
        }
    }
}
