
using Realstate_BL;

public interface IUserManager
{
    public List<UserReadDTO> GetAllUsers();
    public UserReadDTO? GetUserById(Guid id);
    public UserReadDTO AddUser(UserWriteDTO user);
    public bool EditUser(UserWriteDTO user);
    public void DeleteUser(Guid id);

    public List<UserReadDTO> GetAllUsersInCompany();
}
