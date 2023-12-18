using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Application.EmployeeCrud.Interfaces
{
    public interface IEmployeeTableService
    {
       

        Task<IEnumerable> GetById(int id);

        Task<EmployeeDto> Create(EmployeeDto dto);

        Task<EmployeeDto> Edit(EmployeeDto dto, int id);

        Task<bool> Delete(int id);
        Task<IEnumerable<EmployeeDto>> GetAll(int page, string? filter, string sort);
    }
}
