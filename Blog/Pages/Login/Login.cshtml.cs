using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreLayer.DTOs.Users;
using CoreLayer.Services.Users;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Login
{
    [AutoValidateAntiforgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        [Required (ErrorMessage = "نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [MinLength(6,ErrorMessage = "رمز عبور باید بیشتر از 5 کارکتر باشد")]
        public string Password { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var user = _userService.LoginUser(new UserLoginDto()
            {
                Password = Password,
                UserName = UserName
            });
            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test","Test"),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true

            };
            HttpContext.SignInAsync(claimPrincipal, properties);
            return RedirectToPage("../Index");
        }
    }
}
