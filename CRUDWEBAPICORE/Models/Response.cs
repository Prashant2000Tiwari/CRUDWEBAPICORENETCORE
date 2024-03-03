namespace CRUDWEBAPICORE.Models
{
    public class Response
    {
        public int status {  get; set; }

        public string message { get; set; }

        public Employee Employee { get; set; }

        public List<Employee> Employees { get; set;}
    }
}
