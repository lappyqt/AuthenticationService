using AuthenticationService.DAL.Data;

namespace AuthenticationService.DAL.Repositories.Impl;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(DatabaseContext context): base(context) {}
}