using System.Threading.Tasks;
using ASPNetIdentity.Models;
using ASPNetIdentity.Models.Views;
using ASPNetIdentity.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Index(string returnurl=null)
        {
            ViewData["returnURL"] = returnurl;
            return View();
        }

        [HttpGet("SignIn")]
        public IActionResult SignIn(string returnurl=null){
            ViewData["returnURL"] = returnurl;
            var model = new SignIn();
            return View(model);
        }

        [HttpPost("SignIn")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignIn signIn, string returnurl=null){
            ViewData["returnURL"] = returnurl;

            returnurl = returnurl ?? Url.Content("~/");

            if(!ModelState.IsValid){
                return View();
            }

            var response = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, signIn.RememberMe, lockoutOnFailure: false);
            
            if(response.Succeeded){
                return LocalRedirect(returnurl);
            }

            if(response.IsLockedOut){
                return View("Locked");
            }

            ModelState.AddModelError(string.Empty, "Acceso Invalido!");

            return View();
        }

        [HttpGet("SignUp")]
        public IActionResult SignUp(string returnurl=null){
            ViewData["returnURL"] = returnurl;
            var model = new SignUp();
            return View(model);
        }

        [HttpPost("SignUp")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUp signup, string returnurl=null){
            ViewData["returnURL"] = returnurl;

            returnurl = returnurl ?? Url.Content("~/");

            if(!ModelState.IsValid){
                return View();
            }

            User user = _mapper.Map<User>(signup);

            var response = await _userManager.CreateAsync(user, signup.Password);

            if(response.Succeeded){
                await _signInManager.SignInAsync(user, isPersistent: true);
                return LocalRedirect(returnurl);
            }
            
            //mapea errores para que sean mostrados en la vista, 
            //son error que no pertenecen a un campo especifico
            response.ErrorMapper(ModelState);

            return View();
        }

        [HttpPost("SignOut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("signin", "accounts");
        }

        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> Profile(string returnUrl=null){
            ViewData["returnURL"] = returnUrl;

            var email = User.Identity.Name.ToString();
            User user = await _userManager.FindByEmailAsync(email);
            return View(user);
        }

        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword(){
            var fPassword = new ForgotPassword();
            return View(fPassword);
        }

        [HttpPost("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            return View("ConfirmSendEmailForgotPassword");
        }
    }
}