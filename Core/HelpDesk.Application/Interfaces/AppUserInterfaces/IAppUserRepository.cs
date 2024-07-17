namespace HelpDesk.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        AppUser GetAppUserByEmail(string mail);
        AppUser GetUserInfoFromToken(string token);
    }
}
