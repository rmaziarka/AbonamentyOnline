using System;
using Abon.Dto.Portal.Account;

namespace Abon.Interfaces.Services.Portal
{
    public interface IUserService
    {
        bool RegisterUser(UserRegisterDto model, Guid userId);

        bool Validate(string userName, string password);
        bool UserLoginExists(string loginProvider, string providerKey);
        void AddUserLoginToExistingUser(Guid userId, string loginProvider, string providerKey);

        bool ExternalRegistration(ExternalLoginDto model, string providerKey);
    }
}
