namespace HelpDesk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TicketList()
        {
            var values = await _mediator.Send(new GetTicketQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var value = await _mediator.Send(new GetTicketByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket bílgisi başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTicket(int id)
        {
            await _mediator.Send(new RemoveTicketCommand(id));
            return Ok("Ticket bilgisi başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicket(UpdateTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket bilgisi başarılı bir şekilde güncellendi.");
        }
    }
}
