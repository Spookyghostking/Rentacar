using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface ICarBodyTypeBusinessLogic
    {
        List<SelectListItem> GetSelectListItems();
    }
}
