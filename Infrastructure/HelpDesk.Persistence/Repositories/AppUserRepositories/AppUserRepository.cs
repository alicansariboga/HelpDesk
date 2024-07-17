using HelpDesk.Application.Interfaces.AppUserInterfaces;
using HelpDesk.Persistence.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HelpDesk.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly HelpDeskContext _context;

        public AppUserRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public AppUser GetAppUserByEmail(string mail)
        {
            // SELECT * FROM AppUsers WHERE AppUsers.Email='mail address'
            var value = _context.AppUsers.Where(x => x.Email == mail).FirstOrDefault();
            return value;
        }

        public AppUser GetUserInfoFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userId = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var values = _context.AppUsers.Where(x => x.Id == Convert.ToInt32(userId)).Include(x => x.AppUserRoles).FirstOrDefault();

            return (values);
        }
    }
}
