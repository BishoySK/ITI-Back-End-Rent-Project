
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Realstate_DAL;
public class UserRepo : GenericRepo<UserClass> , IUserRepo
{
    private readonly RealstateContext _context;
 

    public UserRepo(RealstateContext context/*, UserManager<UserClass> userManager*/):base(context)
    {
        _context = context;
    }

    public void Add(UserClass user)
    {
        _context.Add(user);
    }

    //public List<UserClass> GetComments()
    //{
    //    return _context.Users.Include(x => x).ToList();   
    //}

    public List<UserClass> GetUsersWithCompany()
    {
        return _context.Users.Include(p => p.CompaniesUsers).ToList();
      
    }

}

