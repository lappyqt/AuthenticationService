using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BL.Models.Account;

public class PasswordResetModel
{
	[Required]
	public string Token { get; set; } = String.Empty;

	[Required, MinLength(6)]
	public string Password { get; set; } = String.Empty;

	[Required, Compare(nameof(Password))]
	public string ConfirmPassword { get; set; } = String.Empty;
}

public class PasswordResetResponseModel : BaseResponseModel {}