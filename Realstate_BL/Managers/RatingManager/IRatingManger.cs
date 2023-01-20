using Realstate_DAL;

namespace Realstate_BL;

public interface IRatingManger
{
    void AddRating (RatingWriteDTOs Rating);
    RatingReadDTOs? GetRatingOfUserById(Guid GetRatingId);
}
