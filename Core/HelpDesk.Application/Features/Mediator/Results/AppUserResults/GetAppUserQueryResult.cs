namespace HelpDesk.Application.Features.Mediator.Results.AppUserResults
{
    public class GetAppUserQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int FailedLoginCount { get; set; }
    }
}
