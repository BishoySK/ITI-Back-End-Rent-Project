using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realstate_BL
{
    public interface IChatManager
    {
        List<ChatReadDTO>? GetAllChat();
        ChatReadDTO? GetChatById(Guid id);
        List<ChatReadDTO> GetLastChat(Guid senderId);

        void AddChat (ChatWriteDTO chat);

        List<ChatReadDTO> GetChatBySenderAndReciver(Guid senderId, Guid reciverId);

    }
}
