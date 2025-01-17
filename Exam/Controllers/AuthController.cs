﻿using Exam.Business.Services.Interfaces;
using Exam.Business.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _service { get; }

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _service.Register(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(vm);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _service.Login(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View(vm);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Index", "Home");
        }
        public async Task<bool> CreateInit()
        {
            return await _service.CreateInits();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        
    }
}
