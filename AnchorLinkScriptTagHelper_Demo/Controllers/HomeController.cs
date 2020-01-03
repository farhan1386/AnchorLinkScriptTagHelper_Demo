using System.Linq;
using AnchorLinkScriptTagHelper_Demo.Data;
using Microsoft.AspNetCore.Mvc;

namespace AnchorLinkScriptTagHelper_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            var employee = dbContext.Employees.ToList();
            return View(employee);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
