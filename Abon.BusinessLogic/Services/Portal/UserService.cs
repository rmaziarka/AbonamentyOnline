using System;
using System.Linq;
using Abon.Database;
using Abon.Database.Model.Portal;
using Abon.Dto.Portal.Account;
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
            AddUser(model, userId);
            AddUserLogin(model, userId);
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



        private void AddUserLogin(UserRegisterDto model, Guid userId)
        {
            var userLogin = new UserLogin()
                            {
                                Id= Guid.NewGuid(),
                                LoginProvider = "Local",
                                ProviderKey = model.Name,
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

        private void AddUser(UserRegisterDto model, Guid userId)
        {
            var user = new User() { Id = userId, Name = model.Name };

            var repo = _unitOfWork.Repository<User>();
            repo.Add(user);
        }
    }
}
