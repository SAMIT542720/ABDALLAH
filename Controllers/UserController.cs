using ABDALLAH.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Samit_For__Trading.Data;
using Samit_For__Trading.Data.Static;
using Samit_For__Trading.Models;

namespace ABDALLAH.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        //LOG IN FUNCTION
        public IActionResult Index() => View(new LoginVM());
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.EmialAddress);
            if (user != null)
            {
                var passowrdcheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passowrdcheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "HOME");
                    }
                }
                TempData["Error"] = "كلمة السر غير صحيحة. من فضلك حاول مرة اخري";
                return View(loginVM);
            }
            TempData["Error"] = "بيانات اعتماد خاطئة ، يرجى المحاولة مرة أخرى";
            return View(loginVM);
        }
        //login out FUNCCTION
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }
        //REGISTER A NEW USER AS A USER
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var User = await _userManager.FindByEmailAsync(registerVM.EmialAddress);
            if (User != null)
            {
                TempData["Error"] = "هذا البريد الإلكتروني قيد الاستخدام بالفعل";
                return View(registerVM);
            }

            var newUser = new User()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmialAddress,
                UserName = registerVM.EmialAddress,
                PhoneNumberTG= (int)registerVM.PhoneNumberTigo,
                PhoneNumberRT= (int)registerVM.PhoneNumberAirtail,
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRole.USER);

            return View("RegisterCompleted");
        }

    }
}
