using System;
using Abon.Dto.Portal.Account;
using Abon.Dto.Portal.Home;
using System.Collections.Generic;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Interfaces.Services.Portal
{
    public interface ICategoryService
    {

        IEnumerable<CategoryDto> GetMainCategories(CategoryType categoryType);
    }
}
