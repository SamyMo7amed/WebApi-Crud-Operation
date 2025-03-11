using Crud_operaiton.Data;
using Crud_operaiton.Modles;
using Crud_operaiton.Modles.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_operaiton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public EmpolyeeController(AppDbContext _app)
        {
            appDbContext = _app;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEMPs()
        {
            var result = await appDbContext.Employees.ToListAsync();    


            return Ok(result);  



        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmpById(Guid id) {

            var emp = appDbContext.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }


            return Ok(emp);
        }
        [HttpPost]
        public IActionResult AddnewEmployee(EmployeeDTO employeeDTO)
        {

            var employee = new Employee() { 
             Email = employeeDTO.Email,
             Name = employeeDTO.Name,   
             Phone = employeeDTO.Phone, 
             Salary = employeeDTO.Salary,   
            };
            appDbContext.Employees.Add(employee);   

            appDbContext.SaveChanges();
            return Ok(employee);





        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, EmployeeDTO employeeDTO) { 
        
        var emp=appDbContext.Employees.Find(id);
            if (emp == null) { 
            return NotFound();
            }
            else
            {
                emp.Name = employeeDTO.Name;
                emp.Phone = employeeDTO.Phone;  
                emp.Salary = employeeDTO.Salary;
                emp.Email = employeeDTO.Email;
                appDbContext.SaveChanges();
                return Ok(emp);
            }
        
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) {

            var emp = appDbContext.Employees.Find(id);
            if (emp == null) {
                return NotFound();
            }
            appDbContext.Employees.Remove(emp);
            appDbContext.SaveChanges(); 
            return Ok();
        
        }

    }
}
