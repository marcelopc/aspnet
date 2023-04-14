using Domain.Entites;

namespace Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
