using CRUDWEBAPICORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CRUDWEBAPICORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;   
        }

        [HttpGet]
        [Route("GetAllEmployees")]

        public Response GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBAppCon").ToString());
            Response response = new Response();
            DataAccessLayer dal = new DataAccessLayer();
            response = dal.GetAllEmployees(con);

            return response;
        }
        
         [HttpGet]
         [Route("GetEmployeesById/{id}")]

        public Response GetEmployeesById(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBAppCon").ToString());
            Response response = new Response();
            DataAccessLayer dal = new DataAccessLayer();
            response = dal.GetEmployeesById(con,id);

            return response;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBAppCon").ToString());
            Response response = new Response();
            DataAccessLayer dal = new DataAccessLayer();
            Employee employee = new Employee();
            employee.Id = emp.Id;
            employee.Name = emp.Name;   
            employee.Email = emp.Email;
            employee.IsActive = emp.IsActive;
            response = dal.AddEmployeesBy(con, employee);

            //or 
            //response = dal.AddEmployeesBy(con, emp);

            return response;
        }

        

        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBAppCon").ToString());
            Response response = new Response();
            DataAccessLayer dal = new DataAccessLayer();
            response = dal.UpdateEmployee(con, emp);

            return response;
        }

        
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBAppCon").ToString());
            Response response = new Response();
            DataAccessLayer dal = new DataAccessLayer();
            response = dal.DeleteEmployee(con, id);

            return response;
        }

    }
}
