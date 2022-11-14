using AuthenticationService.Core.Common;

namespace AuthenticationService.Core.Entities;

public class Account : BaseEntity
{
    public string Email { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;
    public byte[] PasswordHash { get; set; } = new byte[32];
    public byte[] PasswordSalt { get; set; } = new byte[32];
    public string? VerificationToken { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? PasswordResetToken { get; set; } 
    public DateTime? ResetTokenExpires { get; set; }
}