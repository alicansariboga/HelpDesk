namespace HelpDesk.Application.Interfaces.TicketInterfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetTicketByUserId(int id);
        List<Ticket> GetTicketReceiverByUserId(int id);
    }
}
