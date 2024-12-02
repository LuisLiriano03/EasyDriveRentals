using EasyDriveRentals.API.Web.Utility;
using EasyDriveRentals.Application.Genders.Interfaces;
using EasyDriveRentals.Application.Roles.Interfaces;
using EasyDriveRentals.Application.Users.DTOs;
using EasyDriveRentals.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyDriveRentals.API.Web.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class UserController : Controller
    {
        

        private readonly IUserService _userService;
        private readonly IRolService _rolService;
        private readonly IGenderService _genderService;

        public UserController(IUserService userService, IRolService rolService, IGenderService genderService)
        {
            _userService = userService;
            _rolService = rolService;
            _genderService = genderService;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = _rolService.GetAllRolesAsync().Result;
            ViewBag.Genders = _genderService.GetAllGenderAsync().Result;
            return View();
        }

        [HttpGet]
        //[Route("GetAllUser")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users); // Retorna directamente los datos
        }

        [HttpPost]
        //[Route("GetAllUser")]
        public async Task<IActionResult> Register([FromBody] CreateUser user)
        {
            var response = new Response<GetUser>();
            try
            {
                response.status = true;
                response.value = await _userService.Register(user);
                response.message = "Registro exitoso";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

    }
}
