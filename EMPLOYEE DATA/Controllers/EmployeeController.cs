using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EMPLOYEE_DATA;
using EMPLOYEE_DATA.Model;

namespace EMPLOYEE_DATA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee{ Id = 1, Name = "Tanay", Department = "IT"},
            new Employee{ Id = 2, Name = "Tashwin", Department = "HR"}

        };
        [HttpGet]
        public ActionResult <IEnumerable<Employee>> GetAllEmployees()
        {
            return _employees;
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e=> e.Id == id);
            if(existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
    }

}
