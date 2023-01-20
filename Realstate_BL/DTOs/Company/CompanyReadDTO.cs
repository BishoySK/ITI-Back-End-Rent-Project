namespace Realstate_BL;
public class CompanyReadDTO
{
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; } = "";
    public string CompanyImage { get; set; } = "";
    public string Companylocation { get; set; } = "";
    public int CompanyPhoneNumber { get; set; }
    public ICollection<UserCompanyReadDTO> UsersInCompany { get; set; } = new HashSet<UserCompanyReadDTO>();
}

