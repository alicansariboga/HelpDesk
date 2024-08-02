using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> MailList()
        {
            var values = await _mediator.Send(new GetMailQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMail(int id)
        {
            var value = await _mediator.Send(new GetMailByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("MailListByUserId")]
        public async Task<IActionResult> MailListByUserId(int id)
        {
            var values = await _mediator.Send(new GetMailByUserIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMail(CreateMailCommand command)
        {
            await _mediator.Send(command);
            return Ok("Mail bílgisi başarılı bir şekilde eklendi.");
        }
    }
}
