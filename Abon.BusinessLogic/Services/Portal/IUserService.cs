﻿using System;
using System.Security.Claims;
using Abon.Dto.Portal.Account;

namespace Abon.BusinessLogic.Services.Portal
{
    public interface IUserService
    {
        bool RegisterUser(UserRegisterDto model, Guid userId);

        bool Validate(string userName, string password);
        bool UserLoginExists(string loginProvider, string providerKey);
        void AddUserLoginToExistingUser(Guid userId, string loginProvider, string providerKey);

        bool ExternalRegistration(ExternalRegistrationDto model, string providerKey);
    }
}
