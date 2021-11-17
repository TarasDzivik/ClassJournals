using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public string Agenda { get; set; } // Можливо в майбутньому створю ще одну табличку з планами лекцый,
                                           // щоб можна було розділити теми по лекціямм (в ідеалі щоб, коли
                                           // позначав лекцію в розкладі, то воно автоматично розприділяло теми
                                           // лекцій по днях)?
        public long Hours { get; set; }
        public int Raiting { get; set; }

        public int CurrentLectorId { get; set; }
        public Lector Lectors { get; set; }


        public virtual IList<LectorsLecture> LectorsLecture { get; set; }
        public virtual IList<StudentLectures> StudentLectures { get; set; } // Позначив як віртуал, до поки не розберусь як воно працює
        public virtual IList<CoursesLectures> CoursesLectures { get; set; } // (щоб не забути в процесі)
        public virtual ICollection<Course> Courses { get; set; } // Course може мати багато Lectures так і навпаки (many-to-many)

        // Навигационные свойства в Entity Framework позволяют организовать взаимодействие между таблицами базами данных.Как вы уже видели,
        // чтобы в родительском классе сослаться на другой связанный класс, навигационное свойство помечается как виртуальное.В Code-First
        // есть также различные свойства для реализации отношений 0..1-1, 1-1 и many-to-many в таблицах, с которыми мы познакомимся позже,
        // при подробном изучении аспектов Entity Framework.
    }
}