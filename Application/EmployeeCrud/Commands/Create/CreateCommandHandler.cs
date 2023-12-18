using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Interfaces;
using Domain.Dtos;
using MediatR;

namespace Application.EmployeeCrud.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, EmployeeDto>
    {
        private readonly IEmployeeTableService _employeeTablesService;

        public CreateCommandHandler(IEmployeeTableService employeeTablesService)
        {
            _employeeTablesService = employeeTablesService;
        }

        public async Task<EmployeeDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await _employeeTablesService.Create(request.dto);
        }
    }
}
