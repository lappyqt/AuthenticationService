using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BL.Models.Account;

public class LoginAccountModel
{
	[Required]
	public string Username { get; set; } = String.Empty;

	[Required]
	public string Password { get; set; } = String.Empty;
}

public class LoginAccountResponseModel
{
	public string Email { get; set; } = String.Empty;
	public string Username { get; set; } = String.Empty;
	public string Token { get; set; } = String.Empty;
}