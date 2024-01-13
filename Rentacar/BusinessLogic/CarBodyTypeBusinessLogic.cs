using Microsoft.AspNetCore.Mvc.Rendering;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class CarBodyTypeBusinessLogic : ICarBodyTypeBusinessLogic
    {
        private readonly ICarBodyTypeService _carTypes;

        public CarBodyTypeBusinessLogic(ICarBodyTypeService carTypes)
        {
            _carTypes = carTypes;
        }

        public List<SelectListItem> GetSelectListItems()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var type in  _carTypes.GetAll())
            {
                items.Add(new SelectListItem(type.Value, type.ID.ToString()));
            }
            return items;
        }
    }
}
