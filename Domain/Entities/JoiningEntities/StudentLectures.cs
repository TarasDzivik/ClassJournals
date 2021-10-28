using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Domain.Entities.JoiningEntities
{
    public class StudentLectures
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

    }
}
