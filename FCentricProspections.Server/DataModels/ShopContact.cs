namespace FCentricProspections.Server.DataModels
{
    public class ShopContact
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long ContactTypeId { get; set; }
        public long UserCreatedId { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] Timestamp { get; set; }
        public long? Shop_Id { get; set; }
    }
}
