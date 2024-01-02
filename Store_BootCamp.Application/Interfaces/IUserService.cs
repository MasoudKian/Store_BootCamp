namespace Store_BootCamp.Application.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);    
    }
}
