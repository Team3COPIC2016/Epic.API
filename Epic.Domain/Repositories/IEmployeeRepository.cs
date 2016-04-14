using System.Collections.Generic;
using Epic.Domain.Model;

namespace Epic.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Insert(Employee employee, string user);
        IEnumerable<Employee> GetAll();
        void Delete(string id);
        Employee Update(Employee employee, string user);
        Employee Get(string id);
        IEnumerable<Employee> Get(string lastName, string firstName);
        Employee GetByEmployeeId(string employeeId);
    }
}