using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using MediatR;

namespace Application.EmployeeCrud.Commands.Edit
{
    public class EditCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto dto;
        public int _id;

        public EditCommand(EmployeeDto dto,int id)
        {
            this.dto = dto;
            this._id = id;
        }
    }
}
