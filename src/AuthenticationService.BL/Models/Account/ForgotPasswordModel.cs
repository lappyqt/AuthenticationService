namespace AuthenticationService.BL.Models.Account;

public class ForgotPasswordModel
{
	public string Email { get; set; } = String.Empty;
}

public class ForgotPasswordResponseModel : BaseResponseModel {}