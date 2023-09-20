namespace Rentacar.BusinessModels.CarImage
{
    public class CarImageBusinessModel
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public int CarID { get; set; }
        public string CarCodeName { get; set; }
    }
}
