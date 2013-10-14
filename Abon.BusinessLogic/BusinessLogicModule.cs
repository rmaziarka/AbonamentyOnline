using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.BusinessLogic.Services.Portal;
using Abon.Interfaces.Services.Portal;
using Ninject.Modules;

namespace Abon.BusinessLogic
{
    public class BusinessLogicModule : NinjectModule

    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IClaimService>().To<ClaimService>();
            Bind<IOffersService>().To<OffersService>();
        }
    }
}
