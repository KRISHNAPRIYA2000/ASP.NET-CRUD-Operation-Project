using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Interfaces;
using MediatR;

namespace Application.EmployeeCrud.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IEmployeeTableService _employeeTablesService;

        public DeleteCommandHandler(IEmployeeTableService employeeTablesService)
        {
            _employeeTablesService = employeeTablesService;
        }
        public Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var res = _employeeTablesService.Delete(request._id);
            return res;
        }
    }
}
