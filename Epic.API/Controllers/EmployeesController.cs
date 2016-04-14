using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Epic.Domain.Model;
using Epic.Domain.Repositories;
using Epic.Repositories.MongoDB;

namespace Epic.API.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // GET api/employees
        public IEnumerable<Employee> Get()
        {
            var employees = _repository.GetAll().ToList();

            return employees;
        }

        // GET api/employees?id=1231231230-123123123
        public Employee Get(string id)
        {
            var employee = _repository.Get(id);

            return employee;
        }

        // GET api/employees?employeeId=123
        [HttpGet]
        [Route("api/Employees/id/{employeeId}")]
        public Employee GetByEmployeeId(string employeeId)
        {
            var employee = _repository.GetByEmployeeId(employeeId);

            return employee;
        }

        // GET api/employees?lastName=smith&firstName=bob
        public IEnumerable<Employee> Get(string lastName, string firstName)
        {
            var results = _repository.Get(lastName, firstName).ToList();

            return results;
        } 

        public Employee Post([FromBody]Employee employee, string user)
        {
            var insertedEmployee = _repository.Insert(employee, user);

            return insertedEmployee;
        }

        public Employee Put([FromBody] Employee employee, string user)
        {
            var updatedEmployee = _repository.Update(employee, user);

            return updatedEmployee;
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }
    }
}
