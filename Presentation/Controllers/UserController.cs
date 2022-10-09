using DataAccess.Entity;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        private void Authenticate(UserDTO user, IEnumerable<UserDTO> userRole)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.Username),
            };

        }


            [HttpGet]
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(UserDTO userDTO)
        {
            try
            {
                _userService.Login(userDTO);
                Authenticate(userDTO, null);
                return View("Index");
            }
            catch 
            {
                throw new Exception("User not found");    
            }
            //  return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp() 
        {
            return View();
        }


        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(UserDTO userDTO,int userId)
        {
            var res = _userService.Create(userDTO);
            
            return View();
        }
    }
}
