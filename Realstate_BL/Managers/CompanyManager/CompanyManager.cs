using AutoMapper;
using Realstate_BL;
using Realstate_DAL;

public class CompanyManager : ICompanyManager
{

    private readonly ICompanyRepo _companyRepo;
    private readonly IMapper _mapper;
    //private readonly UserManager _userManager;

    public CompanyManager(ICompanyRepo companyRepo, IMapper mapper )
    {

        _companyRepo = companyRepo;
        _mapper = mapper;
        //_userManager = userManager;
    }
    public List<CompanyReadDTO> GetAllCompanies()
    {
        var DbCompany = _companyRepo.GetAll();
        var DTOList = _mapper.Map<List<CompanyReadDTO>>(DbCompany);
        return DTOList;
    }
    public CompanyReadDTO? GetCompanyById(Guid id)
    {
        var DatabaseCompany = _companyRepo.GetById(id);
        if (DatabaseCompany == null)
            return null;
        return _mapper.Map<CompanyReadDTO>(DatabaseCompany);

    }

    public CompanyReadDTO AddCompany(CompanyWriteDTO companyDTO, UserClass user)
    {

        var CompanyDB = _mapper.Map<Company>(companyDTO);
        CompanyDB.CompaniesUsers = new List<CompanyUser>
        {
           new CompanyUser
            {
                IsAdmin = true,
                JoinDate = DateTime.Now,
                UserID = user.Id
            }
        };
       
        _companyRepo.Add(CompanyDB);
        _companyRepo.SaveChanges();

        return _mapper.Map<CompanyReadDTO>(CompanyDB);
    }
    public bool EditCompany(CompanyWriteDTO companyDTO)
    {
        var dbCompany = _companyRepo.GetById(companyDTO.CompanyId);

        if (dbCompany == null)
            return false;

        _mapper.Map(companyDTO,dbCompany);

        _companyRepo.Update(dbCompany);
        _companyRepo.SaveChanges();

        return true;
    }
    public void DeleteCompany(Guid id)
    {
        var dbCompany = _companyRepo.GetById(id);

        if (dbCompany == null)
            return;

        _companyRepo.Delete(dbCompany);
        _companyRepo.SaveChanges();
    }

    public List<CompanyReadDTO> GetCompanyWithUsers()
    {
        var dbcompany = _companyRepo.GetAllUsersOfCompany();
        return _mapper.Map<List<CompanyReadDTO>>(dbcompany);
    }

}
////User.Claims.Where(a=>a.Type == NameIdentitfier);
//CompanyDB.CompanyId = new Guid();
//CompanyUser user = new CompanyUser();
////user.UserID = userId;
//user.CompanyID = CompanyDB.CompanyId;
//user.IsAdmin = true;


//    CompanyDB.Users = new List<CompanyUser>
//{
//    new CompanyUser
//    {
//        IsAdmin= true,
//    }
//};

//new CompanyUser
//{
//    IsAdmin = true,
//    JoinDate = joinDate,
//};