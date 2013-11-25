using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Interfaces;

namespace Abon.BusinessLogic.Services
{
    public class BaseService
    {
        protected IUnitOfWork UnitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

    }
}
