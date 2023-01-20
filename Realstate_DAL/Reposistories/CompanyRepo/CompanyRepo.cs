


using Microsoft.EntityFrameworkCore;
using Realstate_DAL;

public class CompanyRepo : GenericRepo<Company>, ICompanyRepo
{
    private readonly RealstateContext _context;

    public CompanyRepo(RealstateContext context) : base(context)
    {
        _context = context;
    }

    public void Add(/*Guid userId, */Company company)
    {
        _context.Add(company);
    }

    public List<Company> GetAllUsersOfCompany()
    {
        return _context.Companies.Include(c => c.CompaniesUsers).ThenInclude(c=>c.UserClass).ToList();
    }
     
 

}
