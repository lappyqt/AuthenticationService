using System.Security.Cryptography;

namespace AuthenticationService.BL.Helpers;

public static class TokenGeneration
{
	public static string GenerateRandomToken() => Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
}