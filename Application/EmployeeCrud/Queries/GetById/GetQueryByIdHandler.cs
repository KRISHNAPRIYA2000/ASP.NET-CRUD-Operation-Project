using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Interfaces;
using MediatR;

namespace Application.EmployeeCrud.Queries.GetById
{
    public class GetQueryByIdHandler : IRequestHandler<GetQueryById, IEnumerable>
    {
        private readonly IEmployeeTableService _employeeTablesService;

        public GetQueryByIdHandler(IEmployeeTableService employeeTablesService)
        {
            _employeeTablesService = employeeTablesService;
        }

        public async Task<IEnumerable> Handle(GetQueryById request, CancellationToken cancellationToken)
        {
            var res = _employeeTablesService.GetById(request._id);
            return await res;
        }
    }
}
