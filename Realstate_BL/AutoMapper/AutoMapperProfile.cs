using AutoMapper;
using Realstate_BL;
using Realstate_DAL;


namespace Realstate_BL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Advertisement, AdvReadDTO>(); 
            CreateMap<AdvWriteDTO, Advertisement>();

            CreateMap<Company, CompanyReadDTO>()
                .ForMember(c => c.UsersInCompany, m => m.MapFrom(c => c.CompaniesUsers));
            CreateMap<CompanyWriteDTO, Company>();

            CreateMap<UserClass, UserReadDTO>();
            CreateMap<UserWriteDTO, UserClass>();

            CreateMap<UserClass, UserCompanyReadDTO>();
            CreateMap<Company, CompanyUsersReadDTO>();
         


            CreateMap<CompanyUser, UserCompanyReadDTO>()
                .IncludeMembers(c=>c.UserClass);

            CreateMap<Chat, ChatReadDTO>();
            CreateMap<ChatWriteDTO, Chat>();

            CreateMap<Rating,RatingReadDTOs>();
            CreateMap<RatingWriteDTOs,Rating>();
        }
    }
}
