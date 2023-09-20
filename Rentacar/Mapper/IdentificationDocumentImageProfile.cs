using AutoMapper;
using Rentacar.BusinessModels.IdentificationDocumentImage;
using Rentacar.DataModels;

namespace Rentacar.Mapper
{
    public class IdentificationDocumentImageProfile : Profile
    {
        public IdentificationDocumentImageProfile()
        {
            CreateMap<IdentificationDocumentImageDataModel, IdentificationDocumentImageBusinessModel>();
        }
    }
}
