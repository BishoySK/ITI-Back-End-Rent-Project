using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Realstate_BL;

namespace Project_realestate.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvManager _advManager;
        private readonly UserManager<UserClass> _userManager;

        public AdvertisementController(IAdvManager advManager, UserManager<UserClass> userManager)
        {
            _advManager = advManager;
            _userManager = userManager;
        }
        //-------------------get all ads-------------------------------------------//
        [HttpGet]
        public ActionResult<IEnumerable<AdvReadDTO>> GetAllAds()
        {
            return _advManager.GetAllAds();
        }
        //------------------------------get ad by id--------------------------------//
        [HttpGet]
        [Route("GetAdById/{id}")]
        public ActionResult<AdvReadDTO> GetAdById(Guid id)
        {
            var advDTO = _advManager.GetAdvById(id);
            if (advDTO == null)
                return NotFound();
            return advDTO;
        }
        //------------------------------adding adv-------------------------------//

        [HttpPost]
        public async Task<ActionResult> AddAdvirtisement(AdvWriteDTO adv)
        {
            var user = await _userManager.GetUserAsync(User);
            _advManager.AddAdvertisement(adv,user);

            return Ok();
        }


        //----------------------------------filtering ads according to  type/city/no.of rooms----------------
        [HttpGet]
        [Route("filter")]
        public ActionResult<IEnumerable<AdvReadDTO>> GetFiltered(string? type, string? city, int noOfRooms)
        {
            return _advManager.GetFiltered(type, city, noOfRooms);

        }

        //----------------------------deleting ads------------------------------

        [HttpDelete]
        public ActionResult DeleteAdvirtisement(AdvWriteDTO adv)
        {
            _advManager.DeleteAdvertisement(adv);

            return Ok();
        }

        //-----------------------------------------------------------------------

        [HttpGet]
        [Route("GetAdByUserId/{id}")]
        public ActionResult<IEnumerable<AdvReadDTO>> GetAdByUserId(Guid id)
        {
            var advDTO = _advManager.GetAdsByUserId(id);
            if (advDTO == null)
                return NotFound();
            return advDTO;
        }

        //-------------------------------------------------------------------------

        [HttpGet]
        [Route("GetAdByCompanyId/{id}")]
        public ActionResult<IEnumerable<AdvReadDTO>> GetAdByCompanyId(Guid id)
        {
            var advDTO = _advManager.GetAdsByCompanyId(id);
            if (advDTO == null)
                return NotFound();
            return advDTO;
        }




    }
}
