using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebChallenge.DB.Model;

namespace WebChallenge.Contracts.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int employeeId);
        Task<int> AddEmployee(Employee employeeModel);
        void EditEmployee(Employee employeeModel);
        Task<List<Employee>> GetEmployees();
    }
}
