
using Realstate_DAL;

public interface ICompanyRepo : IGenericRepo<Company>
{
    void Add(/*Guid userId,*/ Company company);
    public static DateTime Today { get; }
    List<Company> GetAllUsersOfCompany();
   // Company? GetUserOfCompany(Guid id);


}
