using ClassJournals.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJournals.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;       // Для того щоб у нас був доступ до доменної моделі

        public HomeController(DataManager dataManager) // Передаємо DataManager через HomeController конструктор
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            // Для прикладу виведемо на сторінку адмінки меню з можливістю додати/видалити.редагувати,
            // роззклад, юзера, предмет, курс (вверху сайту)... Поки що просто сторынку заглушку,
            // для тесту прописав
            return View(dataManager.StudentSchedule.GetScheduleItems());
        }
    }
}
