using Exam.Business.Services.Interfaces;
using Exam.Business.ViewModels.MemberVMs;
using Exam.Business.ViewModels.SettingVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SettingController : Controller
    {
        ISettingService _service {  get; }

        public SettingController(ISettingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _service.UpdateAsync(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, SettingUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.UpdateAsync(id, vm);
            return RedirectToAction("Index");
        }
    }
}
