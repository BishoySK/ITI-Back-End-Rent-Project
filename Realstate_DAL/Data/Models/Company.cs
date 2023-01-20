
using System.ComponentModel.DataAnnotations.Schema;

namespace Realstate_DAL;
public class Company
{
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; } = "";
    public string? CompanyImage { get; set; } = "";
    public string Companylocation { get; set; } = "";
    public int CompanyPhoneNumber { get; set; }
    public ICollection<CompanyUser> CompaniesUsers { get; set; } = new HashSet<CompanyUser>();
    public ICollection<Advertisement> advertisements { get; set; } = new HashSet<Advertisement>();

    //[InverseProperty("AddRating")]
    //public ICollection<Rating> SetsRating { get; set; } = new HashSet<Rating>();

    //[InverseProperty("ReciveRating")]
    //public ICollection<Rating> GetsRating { get; set; } = new HashSet<Rating>();
}
