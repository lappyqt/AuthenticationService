using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BL.Models.Account;

public class CreateAccountModel
{
	[Required, EmailAddress]
	public string Email { get; set; } = String.Empty;

	[Required, MinLength(4)]
	public string Username { get; set; } = String.Empty;

	[Required, MinLength(6)]
	public string Password { get; set; } = String.Empty;
}

public class CreateAccountResponseModel : BaseResponseModel  {}