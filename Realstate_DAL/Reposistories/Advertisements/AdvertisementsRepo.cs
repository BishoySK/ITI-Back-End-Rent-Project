namespace Realstate_DAL
{
    public class AdvertisementsRepo : GenericRepo<Advertisement>, IAdvertisementsRepo
    {
        private readonly RealstateContext _Context;
        public AdvertisementsRepo(RealstateContext context) :base(context)
        {
            _Context = context;
        }
        
        public List<Advertisement> GetAdsByCompanyId(Guid companyId)
        {
            return _Context.Advertisements.Where(a => a.Company_Id == companyId).ToList();
        }

  

        public List<Advertisement> GetAdsByUserId(Guid userId)
        {
           return _Context.Advertisements.Where(a=>a.user_Id==userId).ToList();
        }


        public List<Advertisement> GetFiltered(string? type, string? city, int? noOfRooms)
        {
            return _Context.Advertisements
                .Where(a => type == null || type == a.Type)
                .Where(a =>city==null||city==a.City)
                .Where(a=>noOfRooms==null||noOfRooms==a.No_Of_Rooms).ToList();         

        }
    }
}
