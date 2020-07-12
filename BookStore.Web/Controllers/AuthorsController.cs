using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
