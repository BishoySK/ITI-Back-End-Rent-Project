using Microsoft.EntityFrameworkCore;
using Realstate_DAL;

public class ChatRepo : GenericRepo<Chat>, IChatRepo
{
    private readonly RealstateContext _context;

    public ChatRepo(RealstateContext context) : base(context)
    {
        _context = context;
    }



    public List<Chat> GetChatBySenderAndReciver(Guid senderId , Guid reciverId)
    {
        return _context.Chats
            .Where(a => (senderId == a.SenderId && a.ReciverId==reciverId) 
            ||  (reciverId == a.SenderId && a.ReciverId==senderId))
            .ToList();
    }

    public List<Chat> GetLastChat(Guid senderId)
    {
        return _context.Chats.Where(a => a.ReciverId == senderId)
            .GroupBy(a=>a.SenderId)
            .Select(a=> a.OrderByDescending(c=>c.SentDate).First())
            .ToList();
    }

    //public Chat? GetChatAndSeen(Guid id)
    //{
    //    var chatdb = _context.Chat.Find(id);
    //    if (chatdb == null) return null;
    //    chatdb.IsSeen=true;
    //    return 
    //}
}