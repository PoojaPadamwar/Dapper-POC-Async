using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperInAsyncWay.Model;
using DapperInAsyncWay.RepositoryContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperInAsyncWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]       
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return await _employeeRepo.GetEmployee();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetByID(int id)
        {
            return await _employeeRepo.GetByID(id);
        }

        [HttpGet]
        [Route("dob/{dateOfBirth}")]
        public async Task<ActionResult<List<Employee>>> GetByDateOFBirth(DateTime dateOfBirth)
        {
            return await _employeeRepo.GetByDateOfBirth(dateOfBirth);
        }
    }
}
