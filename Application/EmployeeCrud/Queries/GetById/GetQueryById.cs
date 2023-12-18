using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Queries.Get;
using MediatR;

namespace Application.EmployeeCrud.Queries.GetById
{
    public class GetQueryById : IRequest<IEnumerable>
    {
        public readonly int _id;

        public GetQueryById(int id)
        {
            _id = id;
        }

    }
}
