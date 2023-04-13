using Domain.Entites;
using Domain.Interfaces;

namespace Domain.Repository
{
    internal interface IUserRepository: IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
