namespace HelpDesk.Application.Interfaces.MailInterfaces
{
    public interface IMailRepository
    {
        List<Mail> GetMailByUserId(int id);
        List<Mail> GetMailAdminByUserId(int id);
    }
}
