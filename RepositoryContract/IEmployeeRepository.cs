using DapperInAsyncWay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperInAsyncWay.RepositoryContract
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployee();
        Task<Employee> GetByID(int id);
        Task<List<Employee>> GetByDateOfBirth(DateTime dateOfBirth);
    }
}
