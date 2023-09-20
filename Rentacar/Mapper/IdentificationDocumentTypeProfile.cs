using AutoMapper;
using Rentacar.BusinessModels.IdentificationDocumentType;
using Rentacar.DataModels;

namespace Rentacar.Mapper
{
    public class IdentificationDocumentTypeProfile : Profile
    {
        public IdentificationDocumentTypeProfile()
        {
            CreateMap<IdentificationDocumentTypeDataModel, IdentificationDocumentTypeBusinessModel>();
            CreateMap<IdentificationDocumentTypeBusinessModel, IdentificationDocumentTypeDataModel>();
        }
    }
}
