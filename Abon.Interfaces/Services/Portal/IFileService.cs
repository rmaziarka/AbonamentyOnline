using System;
using Abon.Dto.Portal.Account;
using Abon.Dto.Portal.Home;

namespace Abon.Interfaces.Services.Portal
{
    public interface IFileService
    {
        ImageDto GetImage(Guid imageId);
    }
}
