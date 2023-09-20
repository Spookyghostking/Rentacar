using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.IdentificationDocumentType;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class IdentificationDocumentTypeBusinessLogic : IIdentificationDocumentTypeBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly IIdentificationDocumentTypeService _identificationTypes;

        public IdentificationDocumentTypeBusinessLogic(
            IMapper mapper,
            IIdentificationDocumentTypeService identificationTypes)
        {
            _mapper = mapper;
            _identificationTypes = identificationTypes;
        }
        public IEnumerable<IdentificationDocumentTypeBusinessModel> GetAll()
        {
            IEnumerable<IdentificationDocumentTypeDataModel> identificationTypesData = 
                _identificationTypes.GetAll();
            return _mapper.Map<IEnumerable<IdentificationDocumentTypeBusinessModel>>(identificationTypesData);
        }
    }
}
