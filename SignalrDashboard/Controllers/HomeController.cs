using Microsoft.AspNetCore.Mvc;
using SignalrDashboard.Models;
using SignalrDashboard.Repositories;
using System.Diagnostics;

namespace SignalrDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserDetailsRepository _userDetaialsRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userDetaialsRepository=new UserDetailsRepository();
        }

        public IActionResult Index()
        {
            ViewBag.totalUsers = _userDetaialsRepository.GetGeneralData().Item1;
            ViewBag.totalActions = _userDetaialsRepository.GetGeneralData().Item2;

            List<UserGraphData> browserData = _userDetaialsRepository.GetBrowserData();
            List<UserGraphData> deviceData = _userDetaialsRepository.GetDeviceData();
            List<UserGraphData> osData = _userDetaialsRepository.GetOsData();

            ViewBag.BrowserData = browserData;
            ViewBag.DeviceData = deviceData;
            ViewBag.OsData = osData;

            return View();
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