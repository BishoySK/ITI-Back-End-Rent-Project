
namespace Realstate_BL;

public class CompanyWriteDTO
{
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; } = "";
    public string CompanyImage { get; set; } = "";
    public string Companylocation { get; set; } = "";
    public int CompanyPhoneNumber { get; set; }
}
