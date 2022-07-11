using Microsoft.AspNetCore.Mvc;

namespace WebApiModalBinding
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employee = new List<Employee>();
        [HttpPost]
        public IActionResult AddNewEmployee([System.Web.Http.FromBody] Employee employee)
        {
            EmployeeController.employee.Add(employee);
            return Ok("Employee Added");
        }

        [HttpDelete]
        public ActionResult DeleteAnEmployee([System.Web.Http.FromBody] int id)
        {
            var deleteEmployee = employee.Where(x => x.id == id).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employee.Remove(deleteEmployee);
            }
            else
            {
                return Ok($"Record Not found To Delete ");
            }
            return Ok(" Record Delete Successfully");
        }
        [HttpPut]
        public ActionResult UpdateEmployee(int id, [System.Web.Http.FromBody] Employee UpdateEmployee)
        {
            var updatemployee = employee.Where(x => x.id == id).FirstOrDefault();
            if (updatemployee != null)
            {
                updatemployee.id = UpdateEmployee.id;
                updatemployee.name = UpdateEmployee.name;
                updatemployee.age = UpdateEmployee.age;
                updatemployee.address = UpdateEmployee.address;
            }
            else
            {
                return Ok($"Record Not found To Update ");
            }
            return Ok($"Record Updated ");

        }
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            if (employee != null)
            {
                return Ok(employee);
            }
            return BadRequest("No Data Available");
        }
        [HttpPost]
        public async Task<IActionResult> PutEmployeDetailUsingFromQuery([FromQuery] Employee employee)
        {
            EmployeeController.employee.Add(employee);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PutEmployeDetailUsingFromHeader([FromHeader] Employee employee)
        {

            EmployeeController.employee.Add(employee);

            return NoContent();
        }
        [HttpPost("{id}/{name}/{age}/{address}")]
        public async Task<IActionResult> PutEmployeDetailUsingFromRoute([FromRoute] Employee employee)
        {
            EmployeeController.employee.Add(employee);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> SaveEmpAndEdu(EmployeeAndEducation saveEmployeeAndEducation)
        {
            employee.Add(saveEmployeeAndEducation.Employee);
            EmpEducationController.EmpEducations.Add(saveEmployeeAndEducation.EmpEducation);

            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> FromHeadrExample([FromHeader] string name, [FromHeader] Employee employee)
        {
            return Ok($"my name is {name} and my Emp Id= {employee.id}, {employee.age}, {employee.address} ");
        }



    }


}
