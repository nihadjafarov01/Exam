using Exam.Business.Services.Interfaces;
using Exam.Business.ViewModels.MemberVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MemberController : Controller
    {
        IMemberService _service { get; }

        public MemberController(IMemberService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _service.UpdateAsync(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, MemberUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.UpdateAsync(id, vm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
