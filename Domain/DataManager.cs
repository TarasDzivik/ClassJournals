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
        public ILectorsScheduleRepository LectorsSchedule { get; set; }
        public IStudentScheduleRepository StudentSchedule { get; set; }

        public DataManager(
            IStudentRepository studentRepository,
            ILectorRepository lectorRepository,
            ILectureRepository lectureRepository,
            ILectorsScheduleRepository lectorsScheduleRepository,
            IStudentScheduleRepository studentScheduleRepository)
        {
            Student = studentRepository;
            Lector = lectorRepository;
            Lecture = lectureRepository;
            LectorsSchedule = lectorsScheduleRepository;
            StudentSchedule = studentScheduleRepository;
        }
    }
}
