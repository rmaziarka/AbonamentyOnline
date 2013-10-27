using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abon.Core.AutoMapper;
using Abon.Database.Model.Portal;
using Abon.Dto;
using Abon.Dto.Portal.Home;
using Abon.Dto.Portal.Home.Filter;
using Abon.Interfaces;
using Abon.Interfaces.Services.Portal;
using AutoMapper.Internal;
using System.Web.Mvc;
using Abon.Database.Model.Portal.Enums;

namespace Abon.BusinessLogic.Services.Portal
{
    public class FileService : BaseService,IFileService
    {
        public FileService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }



        public ImageDto GetImage(Guid imageId)
        {
            try
            {
                var image = UnitOfWork.Repository<Image>().GetById(imageId);
                return image.Map<ImageDto>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
