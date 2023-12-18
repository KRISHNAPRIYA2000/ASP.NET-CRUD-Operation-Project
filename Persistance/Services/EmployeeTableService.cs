using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EmployeeCrud.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Services
{
    public class EmployeeTableService : IEmployeeTableService
    {
        private readonly ProjectDbContext _dbContext;
       
        public EmployeeTableService(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll(int page, string filter, string sort)
        {
            try
            {
                int pageSize = 5;
                var query = _dbContext.Employees.AsQueryable();

                if (!string.IsNullOrEmpty(filter))
                {
                    query = query.Where(e => e.Description.Contains(filter));
                }

                switch (sort.ToLower())
                {
                    case "asc":
                        query = query.OrderBy(e => e.Salary);
                        break;
                    case "desc":
                        query = query.OrderByDescending(e => e.Salary);
                        break;
                    default:
                        query = query.OrderBy(e => e.Salary);
                        break;
                }

                int totalItems = await query.CountAsync();
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                page = Math.Max(1, Math.Min(page, totalPages));

                var result = await query.Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .Select(e => new EmployeeDto
                        {
                            EmployeeId = e.EmployeeId,
                            EmployeeName = e.EmployeeName,
                            EmployeeAge = e.EmployeeAge,
                            Description = e.Description,
                            Salary = e.Salary,
                            LastModified = e.LastModified,
                            Created = e.Created,
                        })
                        .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }



        public async Task<IEnumerable> GetById(int id)
        {
            try
            {
                var employee = _dbContext.Employees.Where(a => a.EmployeeId == id).ToList();
                if (employee == null)
                {
                    return null;
                }
                else
                {
                    return employee;
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<EmployeeDto> Create(EmployeeDto dto)
        {
            try
            {
                Employee employee = new Employee();
                employee.EmployeeId = dto.EmployeeId;
                employee.EmployeeName = dto.EmployeeName;
                employee.EmployeeAge = dto.EmployeeAge;
                employee.Created = DateTime.Now;
                employee.LastModified = DateTime.Now;
                employee.Salary = dto.Salary;
                employee.Description = dto.Description;

                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return dto;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

       

        public async Task<EmployeeDto> Edit(EmployeeDto dto, int id)
        {
            try
            {
                var employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    employee.EmployeeName = dto.EmployeeName;
                    employee.EmployeeAge = dto.EmployeeAge;
                    employee.Description = dto.Description;
                    employee.Salary = dto.Salary;
                    employee.LastModified = DateTime.Now;

                    _dbContext.SaveChanges();
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var employee = _dbContext.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
                if (employee != null)
                {

                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
