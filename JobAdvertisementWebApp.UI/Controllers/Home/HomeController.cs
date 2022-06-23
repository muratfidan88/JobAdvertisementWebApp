using JobAdvertisementWebApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.UI.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _advertisementService.GetAllFilterAsync(x => x.IsActive == true);
            return View(result.Data);
        }
        public IActionResult Direction()
        {
            var UserRole = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            if (UserRole == "Employer")
                return RedirectToAction("EmployerIndex", "Employer");
            if (UserRole == "Member")
                return RedirectToAction("MemberIndex", "Member");
            return RedirectToAction("Index");
        }
    }
}
