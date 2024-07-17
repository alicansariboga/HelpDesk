namespace HelpDesk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketDocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TicketList()
        {
            var values = await _mediator.Send(new GetTicketDocumentQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var value = await _mediator.Send(new GetTicketDocumentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketDocumentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket dosya bílgisi başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTicket(int id)
        {
            await _mediator.Send(new RemoveTicketDocumentCommand(id));
            return Ok("Ticket dosya bilgisi başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicket(UpdateTicketDocumentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket dosya bilgisi başarılı bir şekilde güncellendi.");
        }
    }
}
