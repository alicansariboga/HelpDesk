namespace HelpDesk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketRoutesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketRoutesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TicketList()
        {
            var values = await _mediator.Send(new GetTicketRouteQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var value = await _mediator.Send(new GetTicketRouteByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketRouteCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket yönlendirme bílgisi başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTicket(int id)
        {
            await _mediator.Send(new RemoveTicketRouteCommand(id));
            return Ok("Ticket yönlendirme bilgisi başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicket(UpdateTicketRouteCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ticket yönlendirme bilgisi başarılı bir şekilde güncellendi.");
        }
    }
}
