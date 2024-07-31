namespace HelpDesk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffDepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffDepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("StaffDepartmentList")]
        public async Task<IActionResult> StaffDepartmentList()
        {
            var values = await _mediator.Send(new GetStaffDepartmentAllQuery());
            return Ok(values);
        }
        [HttpGet("StaffDepartmentListByUserId")]
        public async Task<IActionResult> StaffDepartmentListByUserId(int id)
        {
            var values = await _mediator.Send(new GetStaffDepartmentByUserIdQuery(id));
            return Ok(values);
        }
    }
}
