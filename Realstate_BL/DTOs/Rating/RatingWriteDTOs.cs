namespace Realstate_BL;

public class RatingWriteDTOs
{
    public int Trusted { get; set; }
    public int Avarage { get; set; }
    public int NotTrusted { get; set; }
    public Guid? AddRatingId { get; set; }
    public Guid? ReciveRatingId { get; set; }
}
