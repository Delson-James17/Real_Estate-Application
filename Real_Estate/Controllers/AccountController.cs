using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Real_Estate.Models;
using Real_Estate.ViewModels;

namespace Real_Estate.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; set; }
        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Complete()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userModel = new ApplicationUser
                {
                    Name = userViewModel.Name,
                    Address = userViewModel.Address,
                    Age = userViewModel.Age,
                    DOB = userViewModel.DOB,
                    PhoneNumber = userViewModel.PhoneNumber,
                    UrlImages = userViewModel.UrlImages,
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                };
                var result = await _userManager.CreateAsync(userModel, userViewModel.Password);
                if (result.Succeeded)
                {
                    var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "User");
                    if (role != null)
                    {
                        //var roleResult = await _userManager.AddToRolesAsync(userModel, roles.Select(s => s.Name).ToList());
                        var roleResult = await _userManager.AddToRoleAsync(userModel, role.Name);
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError(String.Empty, "User Role cannot be assigned");
                        }
                    }
                    await _signInManager.SignInAsync(userModel, isPersistent: false);
                    return RedirectToAction("Complete", "Account");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userViewModel);
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                // login activity -> cookie [Roles and Claims]
                var result = await _signInManager.PasswordSignInAsync(userViewModel.Email, userViewModel.Password, userViewModel.RememberMe, false);
                //login cookie and transfter to the client 
                if (result.Succeeded)
                {
                    return RedirectToAction("Properties", "Properties");
                }
                ModelState.AddModelError(string.Empty, "invalid login credentials");
            }
            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Profile()
        {
            var user = await this._userManager.GetUserAsync(this._signInManager.Context.User);
            return View(user);
        }
        public async Task OnGetAsync (string returnUrl = null)
        {
            
        }

       /* [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            ViewBag.UserId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            var model = new List<RoleViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var roleViewModel = new RoleViewModel
                {
                    RoleId = role.Id,
                    Name = role.Name,
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    roleViewModel.IsSelected = true;
                }
                else
                {
                    roleViewModel.IsSelected = false;
                }
                model.Add(roleViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageRoles(List<RoleViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with Id = {userId} cannot be found");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var rolesToAdd = model.Where(r => r.IsSelected && !currentRoles.Contains(r.Name)).Select(r => r.Name);
            var rolesToRemove = currentRoles.Where(r => !model.Any(m => m.IsSelected && m.Name == r));

            var result = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user, rolesToAdd);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }*/

    }
}
        
  
        
