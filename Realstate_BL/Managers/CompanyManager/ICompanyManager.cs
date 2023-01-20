

using Realstate_BL;

public interface ICompanyManager
{
    public List<CompanyReadDTO> GetAllCompanies();
    public CompanyReadDTO? GetCompanyById(Guid id);
    public CompanyReadDTO AddCompany(CompanyWriteDTO company , UserClass user);
    public bool EditCompany(CompanyWriteDTO company);
    public void DeleteCompany(Guid id);

    public List<CompanyReadDTO> GetCompanyWithUsers();
    //void AssignUserToCompany(UserCompanyReadDTO input);


}
