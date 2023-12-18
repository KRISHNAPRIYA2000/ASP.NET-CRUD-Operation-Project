using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Interfaces;
using MediatR;

namespace Application.EmployeeCrud.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetQuery, IEnumerable>
    {
        private readonly IEmployeeTableService _employeeTablesService;

        public GetQueryHandler(IEmployeeTableService employeeTablesService)
        {
            _employeeTablesService = employeeTablesService;
        }
        public async Task<IEnumerable> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            return await _employeeTablesService.GetAll(request._page, request._filter, request._sort);
        }
    }
}
