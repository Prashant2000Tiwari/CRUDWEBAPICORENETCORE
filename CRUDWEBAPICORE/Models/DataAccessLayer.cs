using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUDWEBAPICORE.Models
{
    public class DataAccessLayer
    {
        public Response GetAllEmployees(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM tblCrudNetCore", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            List<Employee> employees = new List<Employee>();
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    employees.Add(employee);    
                }
               
            }
            if(employees.Count > 0)
            {
                response.status = 200;
                response.message = "Data Found";
                response.Employees = employees;
            }
            else
            {
                response.status = 100;
                response.message = "No Data Found";
                response.Employees = null;
            }
            return response;
        }

        public Response GetEmployeesById(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM tblCrudNetCore where Id='"+id+"' AND IsActive = 1", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            Employee employees = new Employee();
            if (dt.Rows.Count > 0)
            {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                    employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    employees = employee;
            }
            if (employees != null)
            {
                response.status = 200;
                response.message = "Data Found";
                response.Employee = employees;
            }
            else
            {
                response.status = 100;
                response.message = "No Data Found";
                response.Employee = null;
            }
            return response;
        }

        public Response AddEmployeesBy(SqlConnection con, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into tblCrudNetCore(Name,Email,IsActive,CreatedOn) VALUES('"+employee.Name+"','"+employee.Email+ "','"+employee.IsActive+ "',GETDATE())", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.status = 200;
                response.message = "Data Found";
                response.Employee = employee;
            }
            else
            {
                response.status = 100;
                response.message = "No Data Found";
                response.Employee = employee;
            }
            return response;
        }

        public Response UpdateEmployee(SqlConnection con, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE tblCrudNetCore SET Name = '" + employee.Name + "',Email = '" + employee.Email + "' WHERE Id = '" + employee.Id+"'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.status = 200;
                response.message = "Data Found";
                response.Employee = employee;
            }
            else
            {
                response.status = 100;
                response.message = "No Data Found";
                response.Employee = employee;
            }
            return response;
        }

        public Response DeleteEmployee(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from tblCrudNetCore WHERE Id = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
           
            if (i>0)
            {
                response.status = 200;
                response.message = "Data Delete";
                
            }
            else
            {
                response.status = 100;
                response.message = "No Data Found";
                
            }
            return response;
        }


    }
}
