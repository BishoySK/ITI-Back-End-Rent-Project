namespace Realstate_BL;

public class RatingReadDTOs
{
    //public Guid Id { get; set; }
    public int Trusted { get; set; }
    public int Avarage { get; set; }
    public int NotTrusted { get; set; }
    public Guid? AddRatingId { get; set; }
    public Guid? ReciveRatingId { get; set; }
}
