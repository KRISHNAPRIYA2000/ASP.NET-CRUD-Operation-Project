using Application.EmployeeCrud.Commands.Create;
using Application.EmployeeCrud.Commands.Delete;
using Application.EmployeeCrud.Commands.Edit;
using Application.EmployeeCrud.Queries.Get;
using Application.EmployeeCrud.Queries.GetById;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudOperationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [Route("GetEmployeeDetails")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int page, string? filter, string sort)
        {
            try
            {
                var res = new GetQuery(page, filter, sort);
                var isSuccess = await _mediator.Send(res);
                if (isSuccess != null)
                {
                    return Ok(isSuccess);
                }
                else
                {
                    return Ok("Nothing to display...!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetEmployeeById")]
        [HttpGet]
        public async Task<IActionResult> GetAllById([FromQuery] int id)
        {
            try
            {
                var res = new GetQueryById(id);
                var isSuccess = await _mediator.Send(res);
                if (isSuccess != null)
                {
                    return Ok(isSuccess);
                }
                else
                {
                    return Ok("Nothing to display...!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("AddEmployee")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            try
            {
                var res = new CreateCommand(dto);
                var isSuccess = await _mediator.Send(res);
                if (isSuccess != null)
                {
                    return Ok("New data added");
                }
                else
                {
                    return Ok("Failed to add new data");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("UpdateEmployee")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EmployeeDto dto, int id)
        {
            try
            {
                var res = new EditCommand(dto,id);
                var isSuccess = await _mediator.Send(res);
                if (isSuccess != null)
                {
                    return Ok(isSuccess);
                }
                else
                {
                    return Ok("Something Wrong!Editing Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("DeleteEmployee")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var query = new DeleteCommand(id);
                var isAuth = await _mediator.Send(query);
                if (isAuth == true)
                {
                    return Ok("Successfully deleted");
                }
                else
                {
                    return Ok("Failed to delete data");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
