using Microsoft.AspNetCore.Mvc;
using AuthenticationService.BL.Models.Account;
using AuthenticationService.BL.Services;
using Microsoft.AspNetCore.Authorization;

namespace AuthenticationService.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly IAccountService _service;

	public AuthenticationController(IAccountService service)
	{
		_service = service;
	}

	[HttpPost("create")]
	[AllowAnonymous]
	public async Task<IActionResult> CreateAccountAsync(CreateAccountModel createAccountModel)
	{
		return Ok(await _service.CreateAccountAsync(createAccountModel));
	}

	[HttpPost("login")]
	[AllowAnonymous]
	public async Task<IActionResult> LoginAsync(LoginAccountModel loginAccountModel)
	{
		return Ok(await _service.LoginAsync(loginAccountModel));
	}

	[HttpPost("confirm")]
	[AllowAnonymous]
	public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
	{
		return Ok(await _service.ConfirmEmailAsync(confirmEmailModel));
	}

	[HttpPost("forgot-password")]
	[AllowAnonymous]
	public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
	{
		return Ok(await _service.ForgotPasswordAsync(forgotPasswordModel));
	}

	[HttpPost("reset-password")]
	[AllowAnonymous]
	public async Task<IActionResult> ResetPasswordAsync(PasswordResetModel passwroResetModel)
	{
		return Ok(await _service.PasswordResetAsync(passwroResetModel));
	}
}