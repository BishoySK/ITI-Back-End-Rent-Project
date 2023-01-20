using Realstate_BL;

namespace Realstate_BL
{
    public interface IAdvManager
    {
        List<AdvReadDTO> GetAllAds();  
        AdvReadDTO? GetAdvById(Guid id);
        void AddAdvertisement(AdvWriteDTO ad);
        void DeleteAdvertisement(AdvWriteDTO ad);
        void UpdateAdvertisement(AdvWriteDTO ad);
        List<AdvReadDTO>? GetAdsByUserId(Guid userId);
        List<AdvReadDTO> GetAdsByCompanyId(Guid companyId);
        List<AdvReadDTO> GetFiltered(string? type,string? City,int? noOfRooms);
        
    }
}
