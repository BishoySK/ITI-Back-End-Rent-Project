using Microsoft.AspNetCore.Identity;
using Realstate_DAL;
using System.ComponentModel.DataAnnotations.Schema;

public class UserClass : IdentityUser<Guid>
{
    public string? UserImage { get; set; } = "";
    public ICollection<CompanyUser> CompaniesUsers { get; set; } = new HashSet<CompanyUser>();

    [InverseProperty("Sender")]
    public ICollection<Chat> SentChats { get; set; } = new HashSet<Chat>();

    [InverseProperty("Reciver")]
    public ICollection<Chat> ReceivedChats { get; set; } = new HashSet<Chat>();
    public ICollection<Advertisement> advertisements { get; set; } = new HashSet<Advertisement>();

    [InverseProperty("AddRating")]
    public ICollection<Rating> SetsRating { get; set; } = new HashSet<Rating>();

    [InverseProperty("ReciveRating")]
    public ICollection<Rating> GetsRating { get; set; } = new HashSet<Rating>();
}
