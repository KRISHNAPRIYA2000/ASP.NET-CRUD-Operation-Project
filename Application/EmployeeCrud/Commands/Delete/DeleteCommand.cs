using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.EmployeeCrud.Commands.Delete
{
    public class DeleteCommand : IRequest<bool>
    {
        public readonly int _id;

        public DeleteCommand(int id)
        {
            _id = id;
        }
    }
}
