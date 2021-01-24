using BACWebsite.Models;
using BACWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BACWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMenuItemRepository _menuItemRepository;

        private readonly IJobTitleRepository _jobTitleRepository;

        public HomeController(ILogger<HomeController> logger, IMenuItemRepository menuItemRepository, IJobTitleRepository jobs)
        {
            _logger = logger;
            _menuItemRepository = menuItemRepository;
            _jobTitleRepository = jobs;
        }


        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("book")]
        public ViewResult BookNow()
        {
            return View();
        }

        [HttpPost("book")]
        public IActionResult BookNow(BookNowViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send the email
                //_mailService.SendMail("marykkrause444@gmail.com", "New Event Requst", $"From: {model.Email}, Name: {model.Name},Date: {model.Date}, Description: {model.Description}")
                ModelState.Clear();
            }
            else
            {
                //show errors
            }

            return View();
        }

        public ViewResult Calendar()
        {
            JobTitleViewModel jobTitleViewModel = new JobTitleViewModel
            {
                Jobs = _jobTitleRepository.AllJobs
            };
            return View(jobTitleViewModel);
        }

        public ViewResult Catering()
        {
            MenuItemListViewModel menuItemListViewModel = new MenuItemListViewModel
            {
                MenuItems = _menuItemRepository.AllMenuItems
            };

            return View(menuItemListViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
