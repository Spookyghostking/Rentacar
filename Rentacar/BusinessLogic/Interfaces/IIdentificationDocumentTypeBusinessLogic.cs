using Rentacar.BusinessModels.IdentificationDocumentType;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface IIdentificationDocumentTypeBusinessLogic
    {
        IEnumerable<IdentificationDocumentTypeBusinessModel> GetAll();
    }
}
