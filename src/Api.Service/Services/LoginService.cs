using Domain.Dtos;
using Domain.Entites;
using Domain.Interfaces.Services.User;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.email))
            {
                return await _repository.FindByLogin(user.email);

            }
   
            return null;
        }
    }
}
