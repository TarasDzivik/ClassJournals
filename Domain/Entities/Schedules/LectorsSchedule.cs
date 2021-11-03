using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities.CoursesAndGrades
{
    public class LectorsSchedule
    {
        public int ScheduleId { get; set; }

        public ICollection<Lector> Lectors { get; set; }

    }
}
