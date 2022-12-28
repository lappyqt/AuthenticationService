using AuthenticationService.DAL.Repositories.Impl;
using AuthenticationService.BL.Models.Account;
using AuthenticationService.DAL.Data;
using AuthenticationService.BL.Helpers;
using AuthenticationService.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.BL.Services.Impl;

public class AccountService : IAccountService
{
	private readonly AccountRepository _repository;
	private readonly IConfiguration _configuration;

	public AccountService(DatabaseContext context, IConfiguration configuration)
	{
		_repository = new AccountRepository(context);
		_configuration = configuration;
	}

	public async Task<CreateAccountResponseModel> CreateAccountAsync(CreateAccountModel createAccountModel)
	{
		PasswordHashing.CreatePasswordHash(createAccountModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

		var account = new Account
		{
			Id = new Guid(),
			Email = createAccountModel.Email,
			Username = createAccountModel.Username,
			PasswordHash = passwordHash,
			PasswordSalt = passwordSalt,
			VerificationToken = TokenGeneration.GenerateRandomToken()
		};

		await _repository.AddAsync(account);
		return new CreateAccountResponseModel { Id = account.Id };
	}

	public async Task<LoginAccountResponseModel> LoginAsync(LoginAccountModel loginAccountModel)
	{
		var account = await _repository.GetAsync(x => x.Username == loginAccountModel.Username);
		bool isPasswordCorrect = PasswordHashing.VerifyPasswordHash(loginAccountModel.Password, account.PasswordHash, account.PasswordSalt);

		if (account == null) throw new Exception("Account not found");
		if (account.VerifiedAt == null) throw new Exception("Account not verified");
		if (isPasswordCorrect == false) throw new Exception("Password is incorrect");

		var token = JwtHelper.GenerateToken(account, _configuration);

		return new LoginAccountResponseModel
		{
			Username = account.Username,
			Email = account.Email,
			Token = token
		};
	}

	public async Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
	{
		var account = await _repository.GetAsync(x => x.VerificationToken == confirmEmailModel.Token);

		if (account == null) throw new Exception("Your verification link is incorrect");

		account.VerifiedAt = DateTime.UtcNow;
		await _repository.UpdateAsync(account);
		return new ConfirmEmailResponseModel { Confirmed = true };
	}

	public async Task<ForgotPasswordResponseModel> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
	{
		var account = await _repository.GetAsync(x => x.Email == forgotPasswordModel.Email);

		if (account == null) throw new Exception("Account not found");

		account.ResetTokenExpires = DateTime.UtcNow.AddDays(3);
		account.PasswordResetToken = TokenGeneration.GenerateRandomToken();
		await _repository.UpdateAsync(account);
		return new ForgotPasswordResponseModel { Id = account.Id};
	}

	public async Task<PasswordResetResponseModel> PasswordResetAsync(PasswordResetModel passwordResetModel)
	{
		var account = await _repository.GetAsync(x => x.PasswordResetToken == passwordResetModel.Token);

		if (account == null) throw new Exception("Account not found");
		if (account.ResetTokenExpires < DateTime.UtcNow) throw new Exception("Token expired or invalid");

		PasswordHashing.CreatePasswordHash(passwordResetModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

		account.PasswordHash = passwordHash;
		account.PasswordSalt = passwordSalt;
		account.PasswordResetToken = null;
		account.ResetTokenExpires = null;

		await _repository.UpdateAsync(account);
		return new PasswordResetResponseModel { Id = account.Id };
	}
}