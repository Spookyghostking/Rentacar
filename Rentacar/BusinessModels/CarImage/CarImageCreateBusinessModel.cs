namespace Rentacar.BusinessModels.CarImage
{
    public class CarImageCreateBusinessModel
    {
        public int CarID { get; set; }
        public IFormFile Image { get; set; }
    }
}
