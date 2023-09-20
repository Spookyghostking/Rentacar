namespace Rentacar.DataModels
{
    public class IdentificationDocumentImageDataModel
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public UserInfoDataModel UserInfo { get; set; }
    }
}
