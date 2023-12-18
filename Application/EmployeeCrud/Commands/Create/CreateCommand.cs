using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using MediatR;

namespace Application.EmployeeCrud.Commands.Create
{
    public class CreateCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto dto;

        public CreateCommand(EmployeeDto dto)
        {
            this.dto = dto;
        }
    }
}
