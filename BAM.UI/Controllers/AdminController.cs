using BAM.Business.Abstract;
using BAM.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BAM.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AdminController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRole()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult AddRole()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityRole<int> role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole<int> newRole = new()
                {
                    Name = role.Name
                };
                var result = await _roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetRole");
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("GetRole");
            }
            return View();
        }
    }
}
