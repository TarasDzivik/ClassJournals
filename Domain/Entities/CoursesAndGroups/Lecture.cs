using ClassJournals.Domain.Entities.JoiningEntities;
using System.Collections.Generic;

namespace ClassJournals.Domain.Entities.CoursesAndGroups
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public long Hours { get; set; }
        public int Raiting { get; set; }

        public int CurrentLectorId { get; set; }
        public Lector Lectors { get; set; }


        public virtual IList<LectorsLecture> LectorsLecture { get; set; }
        public virtual IList<GroupsLectures> GroupsLectures { get; set; }   // Позначив як віртуал, до поки не розберусь як воно працює
        public virtual ICollection<Group> Groups { get; set; }            // Group має багато Lectures так і навпаки (many-to-many)

        // Навигационные свойства в Entity Framework позволяют организовать взаимодействие между таблицами базами данных.Как вы уже видели,
        // чтобы в родительском классе сослаться на другой связанный класс, навигационное свойство помечается как виртуальное.В Code-First
        // есть также различные свойства для реализации отношений 0..1-1, 1-1 и many-to-many в таблицах, с которыми мы познакомимся позже,
        // при подробном изучении аспектов Entity Framework.
    }
}