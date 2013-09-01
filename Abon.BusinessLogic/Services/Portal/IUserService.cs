using System;
using Abon.Dto.Portal.Account;

namespace Abon.BusinessLogic.Services.Portal
{
    public interface IUserService
    {
        bool RegisterUser(UserRegisterDto model, Guid userId);

        bool Validate(string userName, string password);
    }
}
