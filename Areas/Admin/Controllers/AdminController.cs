using ClassJournals.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClassJournals.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> GetRolesAdmin()
        {
            await roleManager.CreateAsync(new IdentityRole
            { Name = "Admin", NormalizedName = "ADMIN" });
            return View(await roleManager.Roles.ToListAsync());
        }
        public async Task<IActionResult> GetRolesStudent()
        {
            await roleManager.CreateAsync(new IdentityRole
            { Name = "Student", NormalizedName = "STUDENT" });
            return View(await roleManager.Roles.ToListAsync());
        }
        public async Task<IActionResult> GetRolesLector()
        {
            await roleManager.CreateAsync(new IdentityRole
            { Name = "Lector", NormalizedName = "LECTOR" });
            return View(await roleManager.Roles.ToListAsync());
        }


    }
}