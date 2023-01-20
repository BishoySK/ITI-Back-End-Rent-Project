
namespace Realstate_BL;

public class UserReadDTO
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public int PhoneNumber { get; set; }
    public string UserImage { get; set; } = "";
    public ICollection<CompanyUsersReadDTO> Companies { get; set; } = new HashSet<CompanyUsersReadDTO>();
}
