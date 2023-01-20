
using System.ComponentModel.DataAnnotations.Schema;

namespace Realstate_DAL;

public class CompanyUser
{
    public Guid CompanyID { get; set; }
    [ForeignKey("UserClass")]
    public Guid UserID { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime JoinDate { get; set; }
    public Company? Company { get; set; }
    public UserClass? UserClass { get; set; }



}
