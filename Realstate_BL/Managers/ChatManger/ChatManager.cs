using AutoMapper;
using Realstate_DAL;

namespace Realstate_BL
{
    public class ChatManager : IChatManager
    {
        private readonly IChatRepo _chatRepo;
        private readonly IMapper _mapper;

        public ChatManager(IChatRepo chatRepo, IMapper mapper)
        {
            _chatRepo = chatRepo;
            _mapper = mapper;
        }
        public void AddChat(ChatWriteDTO chat)
        {
            var dbChat = _mapper.Map<Chat>(chat);
            dbChat.IsSeen = false;
            _chatRepo.Add(dbChat);
            _chatRepo.SaveChanges();
        }

        public List<ChatReadDTO> GetAllChat()
        {
            var dbChat = _chatRepo.GetAll();
            var DTOChat = _mapper.Map<List<ChatReadDTO>>(dbChat);
            return DTOChat;

        }

        public ChatReadDTO? GetChatById(Guid id)
        {
            var dbChat = _chatRepo.GetById(id);
            if (dbChat is null)
                return null;
            return _mapper.Map<ChatReadDTO>(dbChat);
        }

        public List<ChatReadDTO> GetChatBySenderAndReciver(Guid senderId, Guid reciverId)
        {
            var dbChat = _chatRepo.GetChatBySenderAndReciver(senderId, reciverId);
            foreach(var chat in dbChat)
            {
                if(chat.ReciverId== reciverId)
                {
                    chat.IsSeen = true;
                }
            }
            _chatRepo.SaveChanges();
            return _mapper.Map<List<ChatReadDTO>>(dbChat);
        }

        public List<ChatReadDTO> GetLastChat(Guid senderId)
        {
            var dbChats = _chatRepo.GetLastChat( senderId);
            return _mapper.Map<List<ChatReadDTO>>(dbChats); //error here
        }



    }
}