namespace HelpDesk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketStatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TicketList()
        {
            var values = await _mediator.Send(new GetTicketStatusQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var value = await _mediator.Send(new GetTicketStatusByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket durum bílgisi başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTicket(int id)
        {
            await _mediator.Send(new RemoveTicketStatusCommand(id));
            return Ok("Ticket durum bilgisi başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicket(UpdateTicketStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket durum bilgisi başarılı bir şekilde güncellendi.");
        }
    }
}
