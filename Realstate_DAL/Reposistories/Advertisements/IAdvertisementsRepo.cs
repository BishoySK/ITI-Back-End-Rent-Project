namespace Realstate_DAL
{
    public interface IAdvertisementsRepo:IGenericRepo<Advertisement>
    {
        List<Advertisement> GetAdsByUserId(Guid userId); 
        List<Advertisement> GetAdsByCompanyId(Guid companyId);
        List<Advertisement> GetFiltered(string? type,string? city,int? noOfRooms);
    }
}
