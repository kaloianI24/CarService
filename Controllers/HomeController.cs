using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    public class HomeController : Controller
    {
       
        
            public IActionResult Index()
            {
                return View();
            }
        
    }
}
