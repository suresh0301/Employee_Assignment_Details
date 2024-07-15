using AssignmentEmployeeDetails.Models;
using AssignmentEmployeeDetails.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentEmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeDbContext.Employees.ToListAsync();
            return View(employees); 
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeModel addEmployeeRequest)
        {
            var employee = new EmployeeDemo()
           
            {
         
            Id = addEmployeeRequest.Id,
                Name = addEmployeeRequest.Name,
                EmailId = addEmployeeRequest.EmailId,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department,
                Salary = addEmployeeRequest.Salary,
                experience = addEmployeeRequest.experience
            };
            await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var employee= await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            if (employee != null)
            {

                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    EmailId = employee.EmailId,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                    Salary = employee.Salary,
                    experience = employee.experience

                };
                return await Task.Run(()=>View("View",viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee=await employeeDbContext.Employees.FindAsync(model.Id); 
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.EmailId = model.EmailId;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Salary = model.Salary;                 
                employee.Department = model.Department; 
                employee.experience=model.experience;   

                await employeeDbContext.SaveChangesAsync(); 

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await employeeDbContext.Employees.FindAsync(model.Id);
            if (employee !=null)
            {
                employeeDbContext.Employees.Remove(employee);
                await employeeDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
