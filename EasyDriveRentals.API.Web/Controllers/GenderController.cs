using EasyDriveRentals.Application.Genders.Interfaces;
using EasyDriveRentals.Application.Genders.Services;
using EasyDriveRentals.Application.Roles.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyDriveRentals.API.Web.Controllers
{

    public class GenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        //[Authorize]
        [HttpGet]
        //[Route("GetAllGenders")]
        public async Task<IActionResult> GenderList()
        {

            var users = await _genderService.GetAllGenderAsync();
            return Ok(users); // Retorna directamente los datos


        }

    }
}
