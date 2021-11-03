using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities
{
    public class StudentsSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Lector> Lectors { get; set; }

    }
}
