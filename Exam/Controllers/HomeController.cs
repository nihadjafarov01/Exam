using Exam.Business.Services.Interfaces;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        ISettingService _settingService { get;}
        IMemberService _service { get; }

        public HomeController(IMemberService service, ISettingService settingService)
        {
            _service = service;
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            var rdata = data.Where(m => !m.IsDeleted).TakeLast(3);
            ViewBag.Setting = await _settingService.GetAllAsync();
            return View(rdata);
        }
    }
}