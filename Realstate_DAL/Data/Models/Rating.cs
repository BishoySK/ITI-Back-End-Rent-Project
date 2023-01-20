using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realstate_DAL;

public class Rating
{
    
    public Guid Id { get; set; }

    public int Trusted { get; set; }
    public int Avarage { get; set; }
    public int NotTrusted { get; set; }

    public Guid? AddRatingId { get; set; }
    public Guid? ReciveRatingId { get; set; }

    public UserClass? AddRating { get; set; }
    public UserClass? ReciveRating { get; set; }

    //public Company? AddRating { get; set; }
    //public Company? ReciveRating { get; set; }
}
