using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface IIdentificationDocumentTypeService
    {
        IEnumerable<IdentificationDocumentTypeDataModel> GetAll();
        IdentificationDocumentTypeDataModel GetByID(int id);
    }
}
