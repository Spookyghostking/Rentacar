namespace Rentacar.DataModels
{
    public class CarModelDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CarManufacturerDataModel Manufacturer { get; set; }
    }
}
