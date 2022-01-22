using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewModelService _homeViewModelService;
        private readonly UserManager<ApplicationUser> _user;

        public HomeController(ILogger<HomeController> logger, IHomeViewModelService homeViewModelService, UserManager<ApplicationUser> user)
        {
            _logger = logger;
            _homeViewModelService = homeViewModelService;
            _user = user;
        }

        public async Task<IActionResult> Index(int? categoryId, int? brandId)
        {
            return View(await _homeViewModelService.GetHomeViewModelAsync(categoryId, brandId));
        }
        [Authorize]
        public async Task< IActionResult> Chat()
        {
            // ViewBag.userName = _user.GetUserAsync(HttpContext.User);
            var user = await _user.GetUserAsync(User);
           
            // var userName = await _user.GetUserAsync(System.Security.Claims.ClaimsPrincipal.Current);
            return View(user );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
