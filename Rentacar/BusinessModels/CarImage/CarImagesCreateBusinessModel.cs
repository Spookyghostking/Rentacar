namespace Rentacar.BusinessModels.CarImage
{
    public class CarImagesCreateBusinessModel
    {
        public int CarID { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
