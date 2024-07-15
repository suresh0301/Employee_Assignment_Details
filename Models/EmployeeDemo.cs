using Microsoft.EntityFrameworkCore;
namespace AssignmentEmployeeDetails.Models
{
    public class EmployeeDemo
    {
	    public int Id { get; set; }
		public string Name { get; set; }
		public string EmailId { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Department { get; set; }
		public long Salary { get; set; }
		public decimal experience { get; set; }
		


	}
}
