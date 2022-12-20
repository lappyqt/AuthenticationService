using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BL.Models.Account;

public class ConfirmEmailModel
{
	[Required]
	public string Token { get; set; } = String.Empty;
}

public class ConfirmEmailResponseModel
{
	public bool Confirmed { get; set; }
}