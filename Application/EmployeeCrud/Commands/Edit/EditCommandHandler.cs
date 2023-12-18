using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Commands.Create;
using Application.EmployeeCrud.Interfaces;
using Domain.Dtos;
using MediatR;

namespace Application.EmployeeCrud.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommand, EmployeeDto>
    {
        private readonly IEmployeeTableService _employeeTablesService;

        public EditCommandHandler(IEmployeeTableService employeeTablesService)
        {
            _employeeTablesService = employeeTablesService;
        }
        public Task<EmployeeDto> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            return _employeeTablesService.Edit(request.dto,request._id);
        }

    }
}
