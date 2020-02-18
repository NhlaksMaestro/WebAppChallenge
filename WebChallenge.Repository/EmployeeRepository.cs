using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChallenge.Helper.Exceptions;
using WebChallenge.Contracts.Repository;
using WebChallenge.DB.Model;

namespace WebChallenge.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly EmployeeDBContext _dbContext;
        public EmployeeRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddEmployee(Employee employeeModel)
        {
            try
            {
                _dbContext.Employee.Add(employeeModel);
                var id = await _dbContext.SaveChangesAsync();
                return id;
            }
            catch (Exception ex)
            {
                throw new EmployeeRepositoryException(
                    "There was a problem retrieving all employees. Check the inner exception for details.", ex);
            }
        }

        public void EditEmployee(Employee employeeModel)
        {
            try
            {
                var employee = _dbContext.Employee.FirstOrDefault(i => i.Id == employeeModel.Id);
                if (employee != null)
                {
                    employee.Name = employeeModel.Name;
                    employee.Surname = employeeModel.Surname;
                    employee.ManagerId = employeeModel.ManagerId;

                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new EmployeeRepositoryException(
                    "There was a problem retrieving all employees. Check the inner exception for details.", ex);
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            try
            {

                var employee = await _dbContext.Employee.FindAsync(employeeId);
                if (employee == null) throw new EntityNotFoundException($"Could not find a employee with the id {employeeId}.");
                return employee;
            }
            catch (Exception ex)
            {
                throw new EmployeeRepositoryException(
                    "There was a problem retrieving all employees. Check the inner exception for details.", ex);
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                return await Task.Run(() =>
                {
                    return _dbContext.Employee.Include(e => e.Manager).ToList();
                });
            }
            catch (Exception ex)
            {
                throw new EmployeeRepositoryException(
                    "There was a problem retrieving all employees. Check the inner exception for details.", ex);
            }
        }
    }
}
