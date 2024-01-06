using System.Threading.Tasks;
using ASPNetIdentity.Models;
using ASPNetIdentity.Models.Views;
using ASPNetIdentity.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPNetIdentity.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(
            ILogger<AccountsController> logger, 
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("SignIn")]
        public IActionResult SignIn(){
            var model = new SignIn();
            return View(model);
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn(SignIn signIn){
            if(!ModelState.IsValid){
                return View();
            }

            return Redirect("Home");
        }

        [HttpGet("SignUp")]
        public IActionResult SignUp(){
            var model = new SignUp();
            return View(model);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUp signup){
            if(!ModelState.IsValid){
                return View();
            }

            User user = _mapper.Map<User>(signup);

            var response = await _userManager.CreateAsync(user, signup.Password);

            if(response.Succeeded){
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            
            //mapea errores para que sean mostrados en la vista, 
            //son error que no pertenecen a un campo especifico
            response.ErrorMapper(ModelState);

            return View();
        }
    }
}