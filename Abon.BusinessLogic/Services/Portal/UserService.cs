using System;
using System.Linq;
using System.Security.Claims;
using Abon.Database;
using Abon.Database.Model.Portal;
using Abon.Dto.Portal.Account;
using Abon.Interfaces;
using Abon.Interfaces.Services.Portal;
using SimpleCrypto;

namespace Abon.BusinessLogic.Services.Portal
{
    public class UserService:IUserService
    {
        private IUnitOfWork _unitOfWork;
        private ICryptoService _cryptoService;

        public UserService(IUnitOfWork unitOfWork, ICryptoService cryptoService)
        {
            _unitOfWork = unitOfWork;
            _cryptoService = cryptoService;
        }


        public bool RegisterUser(UserRegisterDto model, Guid userId)
        {
            AddUser(model.Name, userId);
            AddUserLogin(model.Name,"Local", userId);
            AddUserSecret(model, userId);
            try
            {
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }



        public bool Validate(string userName, string password)
        {
            var repo = _unitOfWork.Repository<UserSecret>();
            var userSecret = repo.All().FirstOrDefault(el => el.User.Name == userName);
            if (userSecret == null)
                return false;

            var tempHash = _cryptoService.Compute(password, userSecret.Salt);

            return userSecret.Hash == tempHash;
        }

        public bool UserLoginExists(string loginProvider, string providerKey)
        {
           return _unitOfWork.Repository<UserLogin>()
                .All()
                .Any(el => el.LoginProvider == loginProvider && el.ProviderKey == providerKey);
        }

        public void AddUserLoginToExistingUser(Guid userId, string loginProvider, string providerKey)
        {
            var userLogin = new UserLogin()
            {
                Id = Guid.NewGuid(),
                LoginProvider = loginProvider,
                ProviderKey = providerKey,
                UserId = userId
            };

            var repo = _unitOfWork.Repository<UserLogin>();
            repo.Add(userLogin);
        }


        public bool ExternalRegistration(ExternalRegistrationDto model, string providerKey)
        {
            var userId = Guid.NewGuid();
            AddUser(model.UserName, userId);
            AddUserLogin(model.LoginProvider, providerKey, userId);
            try
            {
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        private void AddUserLogin(string loginProvider, string providerKey, Guid userId)
        {
            var userLogin = new UserLogin()
                            {
                                Id= Guid.NewGuid(),
                                LoginProvider = loginProvider,
                                ProviderKey = providerKey,
                                UserId = userId
                            };
            var repo = _unitOfWork.Repository<UserLogin>();
            repo.Add(userLogin);

        }

        private void AddUserSecret(UserRegisterDto model, Guid userId)
        {
            var salt = _cryptoService.GenerateSalt();
            var hash = _cryptoService.Compute(model.Password, salt);
            var userSecret = new UserSecret() {Id = userId, Hash = hash, Salt = salt};

            var repo = _unitOfWork.Repository<UserSecret>();
            repo.Add(userSecret);
        }

        private void AddUser(string name, Guid userId)
        {
            var user = new User() { Id = userId, Name = name};

            var repo = _unitOfWork.Repository<User>();
            repo.Add(user);
        }
    }
}
