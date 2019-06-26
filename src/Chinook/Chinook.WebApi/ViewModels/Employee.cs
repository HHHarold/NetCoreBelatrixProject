namespace Chinook.WebApi.ViewModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int ReportsTo { get; set; }
        public string Email { get; set; }
    }
}
