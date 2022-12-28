using System.Security.Cryptography;
using static System.Text.Encoding;

namespace AuthenticationService.BL.Helpers;

public static class PasswordHashing
{
	public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
	{
		using var hmac = new HMACSHA512();
		passwordSalt = hmac.Key;
		passwordHash = hmac.ComputeHash(UTF8.GetBytes(password));
	}

	public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
	{
		using var hmac = new HMACSHA512(passwordSalt);
		var computedHash = hmac.ComputeHash(UTF8.GetBytes(password));
		return computedHash.SequenceEqual(passwordHash);
	}
}