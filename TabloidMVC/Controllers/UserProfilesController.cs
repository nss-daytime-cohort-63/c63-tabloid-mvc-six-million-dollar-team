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
        
        public ActionResult Details(int id)
        {
             UserProfile userProfile = _userProfileRepository.GetUserById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }


    }
}
