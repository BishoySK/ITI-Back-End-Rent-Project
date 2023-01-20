using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Realstate_BL;

namespace GraduationProjectITI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager _companyManager;
        private readonly UserManager<UserClass> _userManager;

        public CompanyController(ICompanyManager companyManager, UserManager<UserClass> userManager)
        {
            _companyManager = companyManager;
            _userManager = userManager;
        }
        /*******************************************************  GET: api/Companies  ********************************************/
        [HttpGet]
        public ActionResult<IEnumerable<CompanyReadDTO>> GetCompany()
        {
            
            return _companyManager.GetAllCompanies();
        }
        /*******************************************************  GET: api/Company/id  ********************************************/
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<CompanyReadDTO> GetCompany(Guid id)
        {
            var companyDTO = _companyManager.GetCompanyById(id);

            if (companyDTO == null)
            {
                return NotFound();
            }

            return companyDTO;
        }
        /*******************************************************  Put: api/Company  ********************************************/
        [HttpPut]
        public ActionResult PutUser(CompanyWriteDTO CompanyDTO)
        {
            var check = _companyManager.EditCompany(CompanyDTO);
            if (check)
            {
                return NoContent();
            }
            return BadRequest();
        }
        /*******************************************************  Post: api/Company  ********************************************/
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<UserReadDTO>> PostCompany(CompanyWriteDTO Company)
        {
           
            var user = await _userManager.GetUserAsync(User);
            var CompanyDTO = _companyManager.AddCompany(Company, user);

            return CreatedAtAction("GetCompany", new { id = CompanyDTO.CompanyId }, CompanyDTO);
        }
        /*******************************************************  Delete: api/Company  ********************************************/
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(Guid id)
        {
            _companyManager.DeleteCompany(id);
            return NoContent();
        }
        /*******************************************************  GET: api/CompanOfUsers  ********************************************/
        [HttpGet]
        [Route("companyOfUsers")]
        public ActionResult<List<CompanyReadDTO>> GetAllUsersCompany()
        {
            return _companyManager.GetCompanyWithUsers();
        }

    }
}
