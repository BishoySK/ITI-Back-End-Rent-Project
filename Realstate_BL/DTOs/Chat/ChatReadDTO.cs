
namespace Realstate_BL;
public class ChatReadDTO
    {

    public Guid MessageId { get; set; }
    public string MessageContent { get; set; } = "";
    public bool IsSeen { get; set; } = false;
    public DateTime SentDate { get; set; }
    public Guid SenderId { get; set; } 
    public Guid ReciverId { get; set; }

}
