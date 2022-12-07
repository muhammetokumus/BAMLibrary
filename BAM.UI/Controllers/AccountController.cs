using BAM.Entities.Concrete;
using BAM.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace BAM.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUser user, string password)
        {
            if (ModelState.IsValid)
            {
                AppUser user1 = new AppUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    BirthYear = user.BirthYear
                };
                var result = await _userManager.CreateAsync(user, password);
                var role = await _userManager.AddToRoleAsync(user, "Member");
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            var result = _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
