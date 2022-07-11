using Microsoft.AspNetCore.Mvc;

namespace WebApiModalBinding.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeOrganizationController : ControllerBase
    {
        public static List<EmployeeOrgina> Organizations = new List<EmployeeOrgina>();
        [HttpPost]
        public IActionResult AddNewOrganization([System.Web.Http.FromUri] int id, [System.Web.Http.FromUri] string name)
        {
            EmployeeOrgina employeeOrganization = new EmployeeOrgina { Id = id, Name = name };
            Organizations.Add(employeeOrganization);
            return Ok("EmployeeAdded");

        }
        [HttpPut]
        public IActionResult UpdateOrganization([System.Web.Http.FromUri] int id, [System.Web.Http.FromUri] string name)
        {
            var org = Organizations.Where(r => r.Id == id).FirstOrDefault();
            if (org != null)
            {
                org.Id = id;
                org.Name = name;
            }
            else
            {
                return Ok("Not found");

            }
            return Ok("Updated this record");
        }
        [HttpPatch]
        public IActionResult ShowAllOrganization()
        {
            return Ok(Organizations);
        }
        [HttpDelete]
        public IActionResult DeleteOrgainzation([System.Web.Http.FromUri] int id)
        {
            var org = Organizations.Where(r => r.Id == id).FirstOrDefault();
            if (org != null)
            {
                Organizations.Remove(org);
            }
            else
            {
                return Ok("Not Found");
            }
            return Ok("Deleted This Record");
        }
       
       
    }
}