namespace Rentacar.DataModels
{
    public class CarCategoryDataModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public CarBodyTypeDataModel BodyType { get; set; }
        public float DailyFee { get; set; }
        public float FixedFee { get; set; }
    }
}
