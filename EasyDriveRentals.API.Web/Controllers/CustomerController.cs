using Microsoft.AspNetCore.Mvc;

namespace EasyDriveRentals.API.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }


    }
}
