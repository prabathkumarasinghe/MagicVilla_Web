using MagicVilla_Web.Model.Dto;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginRequestDto loginRequestDto = new LoginRequestDto();
			return View(loginRequestDto);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterationRequestDto registerationRequestDto)
		{
			APIResponse result = await _authService.RegisterAsync<APIResponse>(registerationRequestDto);
			if (result != null && result.IsSuccess)
			{
				return RedirectToAction("Login");
			}

			return View();
		}

		public async Task<IActionResult> Logout() 
		{
			return View();
		}
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}