using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;
using Real_Estate.ViewModels;

namespace Real_Estate.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Details(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            return View(user);
        }
        public async Task<IActionResult> Delete(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var userlist = await _userManager.DeleteAsync(user);
            return RedirectToAction(controllerName: "Users", actionName: "GetAllUsers"); // reload the getall page it self
        }
       

        [HttpGet]
        public async Task<IActionResult> Update(string userId)
        {
            var users = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var roles = await _userManager.GetRolesAsync(users);
            EditUserViewModel userViewModel = new EditUserViewModel()
            {  
                Name= users.Name,
                Age= users.Age,
                Address= users.Address, 
                DOB = (DateTime)users.DOB,
                PhoneNumber = users.PhoneNumber,
                UrlImages = users.UrlImages,
                UserName= users.UserName,
                Email = users.Email,
                Roles = roles

            };
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Update(EditUserViewModel user)
        {
            //var user = _userManager.Users.FirstOrDefault(u => u.Id == newUser);

            return RedirectToAction("GetAllUsers");
        }
       
        }
    

    }

