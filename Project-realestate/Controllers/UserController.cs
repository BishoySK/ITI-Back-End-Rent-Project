
using Microsoft.AspNetCore.Mvc;
using Realstate_BL;

namespace GraduationProjectITI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        /*****************************************  GET: api/Users  *******************************/
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            return _userManager.GetAllUsers();
        }
        /******************************************  GET: api/User/id  *******************************/
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<UserReadDTO> GetUser(Guid id)
        {
            var userDTO = _userManager.GetUserById(id);

            if (userDTO == null)
            {
                return NotFound();
            }

            return userDTO;
        }
        /****************************************  Put: api/Users  ***********************************/
        [HttpPut]
        public ActionResult PutUser(UserWriteDTO userDTO)
        {
            var check = _userManager.EditUser(userDTO);
            if (check)
            {
                return NoContent();
            }
            return BadRequest();
        }
        /***************************************  Put: api/Users  **************************************/
        [HttpPost]
        public ActionResult<UserReadDTO> PostUser(UserWriteDTO userDTO)
        {
            var UserReadDTO = _userManager.AddUser(userDTO);

            return CreatedAtAction("GetUser", new { id = UserReadDTO }, UserReadDTO);
        }
        /**************************************  Delete: api/Users  *************************************/
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            _userManager.DeleteUser(id);
            return NoContent();
        }
        /*****************************************  GET: api/CompanOfUsers  ***********************************/
        [HttpGet]
        [Route("companyOfUsers")]
        public ActionResult<List<UserReadDTO>> GetAllUsersCompany()
        {
            return _userManager.GetAllUsersInCompany();
        }
    }
}
