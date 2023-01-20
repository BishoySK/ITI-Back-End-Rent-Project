using AutoMapper;
using Realstate_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realstate_BL;

public class RatingManger : IRatingManger
{
    private readonly IRatingRepo _ratingRepo;
    private readonly IMapper _mapper;

    public RatingManger(IRatingRepo ratingRepo,IMapper mapper)
    {
        _ratingRepo = ratingRepo;
        _mapper = mapper;
    }

    public void AddRating(RatingWriteDTOs RatingDTOs)
    {
        var DbRating = _ratingRepo.GetRatingById(RatingDTOs.ReciveRatingId.GetValueOrDefault());
        if (DbRating != null)
        {
            _mapper.Map(RatingDTOs, DbRating);
        }
        else
        {
            var dbRating = _mapper.Map<Rating>(RatingDTOs);
            dbRating.Id=Guid.NewGuid();
            _ratingRepo.Add(dbRating);
        }
        _ratingRepo.SaveChanges();
    }

    public RatingReadDTOs? GetRatingOfUserById(Guid UserId)
    {
        var DbRating = _ratingRepo.GetRatingById(UserId);

        if (DbRating is null) return null;

       var UserRatingDTO = _mapper.Map<RatingReadDTOs>(DbRating);

        return UserRatingDTO;
    }
}
