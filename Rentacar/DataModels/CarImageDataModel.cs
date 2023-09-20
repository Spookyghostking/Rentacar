namespace Rentacar.DataModels
{
    public class CarImageDataModel
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public CarDataModel Car { get; set; }
    }
}
