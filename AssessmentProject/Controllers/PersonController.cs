using AssessmentProject.Controllers.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AssessmentProject.Service.Api.Controllers
{
    [ApiController]
    [Route($"api/v1/[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(IPersonService personService,
            ILogger<PersonController> logger)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost("Login", Name = "Login Person and get JWT Token")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(LoginRequestDTO))]
        public async Task<IActionResult> LoginPerson([FromBody] LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken)
        {
            try
            {
                var jwt = await _personService.Authenticate(loginRequestDTO);
                return StatusCode(
                    statusCode: (int)HttpStatusCode.OK,
                    value: jwt);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost("Register", Name = "Register Person")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.Created, type: typeof(PersonDto))]
        public async Task<IActionResult> RegisterPerson([FromBody] PersonDto personDto, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personService.CreatePerson(personDto);
                return StatusCode(
                    statusCode: (int)HttpStatusCode.Created, value: person);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update", Name = "Update Person")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent, type: typeof(PersonDto))]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonWithIdDto personDto, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personService.UpdatePerson(personDto);
                return StatusCode(
                    statusCode: (int)HttpStatusCode.Created,
                    value: person
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Deactivate", Name = "Deactivate Person")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.Created, type: typeof(PersonDto))]
        public async Task<IActionResult> DeactivatePerson(Guid personId)
        {
            try
            {
                await _personService.DeactivatePerson(personId);
                return StatusCode(
                    statusCode: (int)HttpStatusCode.OK, value: $"Person Deactivated");
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Activate", Name = "Activate Person")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.Created, type: typeof(PersonDto))]
        public async Task<IActionResult> ActivatePerson(Guid personId)
        {
            try
            {
                await _personService.ActivatePerson(personId);
                return StatusCode(
                    statusCode: (int)HttpStatusCode.OK, value: $"Person Activated");
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("PersonList", Name = "Get Person List")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(PersonDto))]
        public async Task<IActionResult> PersonList()
        {
            try
            {
                var persons = await _personService.GetPersons();
                return StatusCode(
                    statusCode: (int)HttpStatusCode.OK,
                    value: persons
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("", Name = "Get Person By Id")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(PersonDto))]
        public async Task<IActionResult> Person(Guid personid)
        {
            try
            {
                var persons = await _personService.GetPerson(personid);
                return StatusCode(
                    statusCode: (int)HttpStatusCode.OK,
                    value: persons
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: (int)HttpStatusCode.BadRequest,
                    value: $"Bad request message: {ex.Message}");
            }
        }
    }
}
