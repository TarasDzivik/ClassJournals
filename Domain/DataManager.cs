using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassJournals.Domain.Entities;
using ClassJournals.Domain.Repositories.Abstract;

namespace ClassJournals.Domain
{
    public class DataManager 
    {
        /* Клас який централізовано керуватиме нашими репозиторіями. Замість того щоб окремо передавати
        кожний репозиторії для управління послугами і текстовими полями ми будемо передавати в контроллер
        наприклад клас "DataManager" і уже через властивості цього класу наприклад Student, які будуть
        зв'язані з імплементацією репозиторія. */

        public IStudentRepository Student { get; set; }
        public ILectorRepository Lector { get; set; }
        public ILectureRepository Lecture { get; set; }
        public IScheduleRepository Schedule { get; set; }

        public DataManager(
            IStudentRepository studentRepository,
            ILectorRepository lectorRepository,
            ILectureRepository lectureRepository,
            IScheduleRepository scheduleRepository)
        {
            Student = studentRepository;
            Lector = lectorRepository;
            Lecture = lectureRepository;
            Schedule = scheduleRepository;
        }
    }

}
