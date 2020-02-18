using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppChallenge.Helper.Exceptions;
using WebChallenge.Contracts.Repository;
using WebChallenge.DB.Model;

namespace WebAppChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController: BaseController
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employeeModel = await _employeeRepository.GetEmployee(id);
                return Ok(employeeModel);
            }
            catch (Exception ex)
            {
                return FormatException<EmployeeControllerException>(
                    "There was a problem retrieving the employee. Check the inner exception for details.", ex);
            }
        }

        // GET: api/Employees
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employeeModels = await _employeeRepository.GetEmployees();
                return Ok(employeeModels);
            }
            catch (Exception ex)
            {
                return FormatException<EmployeeControllerException>(
                    "There was a problem retrieving the employees. Check the inner exception for details.", ex);
            }
        }
        // Put: api/Employee
        [HttpPut()]
        public void PutEmployee(Employee employee)
        {
            try
            {
                _employeeRepository.EditEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new EmployeeControllerException("There was a problem editing the Employee. Check the inner exception for details.", ex);
            }
        }
        // Post: api/Employee
        [HttpPost()]
        public async Task<IActionResult> PostEmployee(Employee employee)
        {
            try
            {
                var employeeId = await _employeeRepository.AddEmployee(employee);
                return Ok(employeeId);
            }
            catch (Exception ex)
            {
                return FormatException<EmployeeControllerException>(
                    "There was a problem adding a new employee. Check the inner exception for details.", ex);
            }
        }
    }
}
