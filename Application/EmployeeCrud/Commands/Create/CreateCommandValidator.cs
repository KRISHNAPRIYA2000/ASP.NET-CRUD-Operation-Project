using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using FluentValidation;

namespace Application.EmployeeCrud.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<EmployeeDto>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.EmployeeName).NotNull();
            RuleFor(x => x.EmployeeId).NotNull();
            RuleFor(x => x.EmployeeAge).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Salary).NotNull();

            RuleFor(x => x.EmployeeName).Matches("^[a-zA-Z ]+$").
                WithMessage("Only letters and spaces are allowded in this field");

            RuleFor(x => x.EmployeeId).Must(employeeId => int.TryParse(employeeId.ToString(), out _)).
                WithMessage("Only numbers are allowed in the EmployeeId field");

            RuleFor(x => x.EmployeeAge).Must(employeeAge => int.TryParse(employeeAge.ToString(), out _)).
                WithMessage("Only numbers are allowed in the EmployeeAge field");

            RuleFor(x => x.Salary).Must(salary => decimal.TryParse(salary.ToString(), out _)).
                WithMessage("Only numbers are allowed in the Salary field");


        }
    }
}
