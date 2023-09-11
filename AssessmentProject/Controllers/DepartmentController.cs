using AssessmentProject.Controllers.DTOs;
using AssessmentProject.Models;
using AssessmentProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AssessmentProject.Service.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpPost("Create", Name = "Create Department")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.Created, type: typeof(Department))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto, CancellationToken cancellationToken)
        {
            try
            {
                var department = MapDtoToDepartment(departmentDto);
                var createdDepartment = await _departmentService.CreateDepartment(department);
                return StatusCode((int)HttpStatusCode.Created, createdDepartment);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request message: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{departmentId}", Name = "Delete Department")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> DeleteDepartment(Guid departmentId)
        {
            try
            {
                await _departmentService.DeleteDepartment(departmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request message: {ex.Message}");
            }
        }

        [HttpGet("GetDepartmentsByPerson/{personId}", Name = "Get Departments by Person")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(IEnumerable<Department>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> GetDepartmentsByPerson(Guid personId)
        {
            try
            {
                var departments = await _departmentService.GetDepartmentsbyPerson(personId);
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request message: {ex.Message}");
            }
        }

        [HttpGet("GetAllDepartments", Name = "Get All Departments")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(IEnumerable<Department>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var departments = await _departmentService.GetDepartments();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request message: {ex.Message}");
            }
        }

        // Helper method to map DTO to Department
        private Department MapDtoToDepartment(DepartmentDto departmentDto)
        {
            var department = new Department { Name = departmentDto.Name, PersonId = departmentDto.PersonId };

            return department;
        }
    }
}
