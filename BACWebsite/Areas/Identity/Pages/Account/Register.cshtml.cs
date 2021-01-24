using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BACWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using BACWebsite.ViewModels;

namespace BACWebsite.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        public readonly JobTitleViewModel _jobs;
        public readonly List<string> _roles = new List<string>();

        public RegisterModel(
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            RoleManager<IdentityRole> roleManager,
            IJobTitleRepository jobs,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            foreach (var role in _roleManager.Roles)
            {
                _roles.Add(role.Name);
            }
            _roles.Sort();
            _jobs = new JobTitleViewModel
            {
                Jobs = jobs.AllJobs
            };

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = "Birthday Required.")]
            public string Birthday { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = "First Name Required.")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = "Last Name Required.")]
            public string LastName { get; set; }

            [Required]
            public int JobTitleId { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            [Required]
            public string RoleName { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new Employee { UserName = Input.UserName, Birthday = DateTime.Parse(Input.Birthday), PhoneNumber = Input.PhoneNumber,
                                          FirstName = Input.FirstName, LastName = Input.LastName, JobTitleId = Input.JobTitleId, Address = Input.Address};
                var result1 = await _userManager.CreateAsync(user, Input.Password);
                var result2 = await _userManager.AddToRoleAsync(user, Input.RoleName);
                
                if (result1.Succeeded && result2.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    _logger.LogInformation("User assigned to role.");

                    return RedirectToAction("SuccessfulRegistration", "EmployeeOnly");
                }
                foreach (var error in result1.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                foreach (var error in result2.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
