using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Realstate_BL;

namespace Project_realestate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingManger _ratingManger;

        public RatingController(IRatingManger ratingManger)
        {
            _ratingManger = ratingManger;
        }
        
        [HttpPost]
        public ActionResult AddingRating(RatingWriteDTOs ratingWriteDTOs)
        {
            _ratingManger.AddRating(ratingWriteDTOs);

            return Ok();
        }

        [HttpGet]
        [Route("GetRatingOfUser/{id}")]
        public ActionResult<RatingReadDTOs> GetRatingOfUserById(Guid UserId)
        {
            var DbUserRating = _ratingManger.GetRatingOfUserById(UserId); 

                if(DbUserRating is null)
                return NotFound(new {Message="User doesn't exsists!"});

            return DbUserRating;
        }
    }
}
