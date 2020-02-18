using Dapper;
using DapperInAsyncWay.Model;
using DapperInAsyncWay.RepositoryContract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperInAsyncWay.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly IConfiguration _config;

        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }

        public async Task<Employee> GetByID(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT ID, FirstName, LastName, DateOfBirth FROM Employee WHERE ID = @ID; Select FullAddress, AddID ,EmpID from Address WHERE EmpID = @ID";
                conn.Open();

                var result = await conn.QueryMultipleAsync(sQuery, new { ID = id });

                var emp=result.Read<Employee>().Single();
                var add = result.Read<Address>();
                emp.EmpAddress = add.ToList();
                return emp;
            }
        }

        public async Task<List<Employee>> GetEmployee()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT ID, FirstName, LastName, DateOfBirth, FullAddress , AddID ,EmpID from Employee inner join Address on Employee.ID= Address.EmpID ";
                conn.Open();
                
                var empDictionary = new Dictionary<int, Employee>();              

                var list = conn.Query<Employee, Address, Employee>(
                sQuery,
                (emp, add) =>
                {
                    if (!empDictionary.TryGetValue(emp.ID, out Employee empEntry))
                    {
                        empEntry = emp;
                        empEntry.EmpAddress = new List<Address>();
                        empDictionary.Add(empEntry.ID, empEntry);
                    }
                    empEntry.EmpAddress.Add(add);
                    return empEntry;
                },
                splitOn: "AddID").Distinct();               
           
                
                return list.ToList();
            }
        }


        public async Task<List<Employee>> GetByDateOfBirth(DateTime dateOfBirth)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT ID, FirstName, LastName, DateOfBirth FROM Employee WHERE DateOfBirth = @DateOfBirth";
                conn.Open();
                var result = await conn.QueryAsync<Employee>(sQuery, new { DateOfBirth = dateOfBirth });
                return result.ToList();
            }
        }
    }
}
