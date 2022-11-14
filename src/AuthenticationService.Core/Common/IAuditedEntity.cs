namespace AuthenticationService.Core.Common;

public interface IAuditedEntity 
{
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; } 
}