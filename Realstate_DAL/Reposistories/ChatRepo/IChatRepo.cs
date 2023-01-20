using Realstate_DAL;

public interface IChatRepo : IGenericRepo<Chat>
{
     List<Chat> GetChatBySenderAndReciver(Guid senderId, Guid reciverId);
     List<Chat> GetLastChat(Guid senderId);
}