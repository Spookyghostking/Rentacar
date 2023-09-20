using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface IIdentificationDocumentImageService
    {
        IEnumerable<IdentificationDocumentImageDataModel> GetByUserInfoID(int id);
    }
}
