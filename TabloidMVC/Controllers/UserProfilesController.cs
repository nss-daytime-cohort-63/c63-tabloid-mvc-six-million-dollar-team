using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TabloidMVC.Models;
using System.Security.Claims;
using TabloidMVC.Repositories;

namespace TabloidMVC.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfilesController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        // GET: HomeController1
        [Authorize]
        public ActionResult Index()
        {
            var userProfile = _userProfileRepository.GetUserProfile();
            return View(userProfile);
        }
        public IActionResult Details(int id)
        {
            var user = _userProfileRepository.GetUserById(id);
            return View(user);
        }


    }
}
