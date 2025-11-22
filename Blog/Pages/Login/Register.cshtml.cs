using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DTOs.Users;
using CoreLayer.Services.Users;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages.Login
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private IUserService _userService;


        #region Peroperties
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کارکتر باشد")]
        public string Password { get; set; }
        #endregion




        public RegisterModel (IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var result = _userService.RegisterUser(new UserRegisterDto()
            {
                UserName = UserName,
                FullName = FullName,
                Password = Password
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName",result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
