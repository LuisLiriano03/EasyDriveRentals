using EasyDriveRentals.API.Web.Utility;
using EasyDriveRentals.Application.Roles.DTOs;
using EasyDriveRentals.Application.Roles.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyDriveRentals.API.Web.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        //[Authorize]
        [HttpGet]
        //[Route("GetAllRoles")]
        public async Task<IActionResult> GetRoles()
        {

            var users = await _rolService.GetAllRolesAsync();
            return Ok(users); // Retorna directamente los datos
            

        }



    }
}
