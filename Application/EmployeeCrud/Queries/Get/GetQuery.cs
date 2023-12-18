using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.EmployeeCrud.Queries.Get
{
    public class GetQuery : IRequest<IEnumerable>
    {
        public readonly string _filter;
        public int _page;
        public string _sort;

        public GetQuery(int page, string filter, string sort)
        {
            _filter = filter;
            _page = page;
            _sort = sort;
        }
    }
}
