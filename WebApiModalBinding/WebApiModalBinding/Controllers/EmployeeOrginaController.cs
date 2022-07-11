using Microsoft.AspNetCore.Mvc;
namespace WebApiModalBinding
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        [HttpDelete]
        public IActionResult DeleteOrgainzation([System.Web.Http.FromUri] int id)
        {
            var orgination = Organizations.Where(r => r.Id == id).FirstOrDefault();
            if (orgination != null)
            {
                Organizations.Remove(orgination);
            }
            else
            {
                return Ok("record Not Found");
            }
            return Ok("Deleted the record");
        }
        [HttpPut]
        public IActionResult UpdateOrganization([System.Web.Http.FromUri] int id, [System.Web.Http.FromUri] string name)
        {
            var orgination = Organizations.Where(r => r.Id == id).FirstOrDefault();
            if (orgination != null)
            {
                orgination.Id = id;
                orgination.Name = name;
            }
            else
            {
                return Ok("Not found");

            }
            return Ok("Updated the Employee");
        }
        [HttpPatch]
        public IActionResult ShowAllOrganization()
        {
            return Ok(Organizations);
        }
    }
}
