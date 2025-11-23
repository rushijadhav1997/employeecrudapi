using demoapiproject.Data;
using demoapiproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoapiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// for this return the schema in swagger need to show 
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }
        /// <summary>
        /// for this not return the schema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getemployee")]
        public async Task<IActionResult> GetEmployeess()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetEmployees(int id )
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

            if (employees == null)
                return NotFound("employees not found");
            return Ok(employees);
        }

        //============================
        //post
        //============================
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee added successfully", emp });
        }

        /// <summary>
        /// its will add only partuclar value firstName and firstName not whole body 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee(string firstName, string lastName)
        {
            var emp = new Employee
            {
                FirstName = firstName,
                LastName = lastName
            };

            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee inserted", emp });
        }
        // ===========================
        // PUT - Update
        // ===========================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee emp)
        {
            var existingEmp = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

            if (existingEmp == null)
                return NotFound();

            existingEmp.FirstName = emp.FirstName;
           

            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee updated successfully", existingEmp });
        }
        /// <summary>
        /// it will update only firstanme on thebasi of id not whole body 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [HttpPut("update-firstname")]
        public async Task<IActionResult> UpdateFirstName(int id, string firstName)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
                return NotFound("Employee not found.");

            emp.FirstName = firstName;
            emp.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new { message = "FirstName updated successfully", emp });
        }

        // ===========================
        // DELETE
        // ===========================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

            if (emp == null)
                return NotFound();

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee deleted successfully" });
        }

    }
}
