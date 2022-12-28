using AuthenticationService.BL.Models.Account;

namespace AuthenticationService.BL.Services;

public interface IAccountService
{
	Task<CreateAccountResponseModel> CreateAccountAsync(CreateAccountModel createAccountModel);
	Task<LoginAccountResponseModel> LoginAsync(LoginAccountModel loginAccountModel);
	Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel);
	Task<ForgotPasswordResponseModel> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel);
	Task<PasswordResetResponseModel> PasswordResetAsync(PasswordResetModel passwordResetModel);
}