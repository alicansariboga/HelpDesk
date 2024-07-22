using HelpDesk.DTO.TicketDtos;
using HelpDesk.DTO.TicketStatusDtos;

namespace HelpDesk.WebUI.Models
{
    public class CreateTicketViewModel
    {
        public CreateTicketDto createTicketDto { get; set; }
        public List<ResultTicketStatusDto> resultTicketStatusDtos { get; set; }
    }
}
