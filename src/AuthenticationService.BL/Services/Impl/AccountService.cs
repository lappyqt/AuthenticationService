using AuthenticationService.BL.Models.Account;

namespace AuthenticationService.BL.Services.Impl;

public class AccountService : IAccountService
{
	public Task<CreateAccountResponseModel> CreateAccountAsync(CreateAccountModel createAccountModel)
	{
		throw new NotImplementedException();
	}

	public Task<LoginAccountResponseModel> LoginAsync(LoginAccountModel loginAccountModel)
	{
		throw new NotImplementedException();
	}

	public Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel configEmailModel)
	{
		throw new NotImplementedException();
	}

	public Task<ForgotPasswordResponseModel> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
	{
		throw new NotImplementedException();
	}

	public Task<PasswordResetResponseModel> PasswordResetAsync(Guid id, PasswordResetModel passwordResetModel)
	{
		throw new NotImplementedException();
	}
}