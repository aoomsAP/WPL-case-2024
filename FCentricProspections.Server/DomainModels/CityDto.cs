namespace FCentricProspections.Server.DomainModels
{
    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public long CountryId { get; set; }
        public CountryDto Country {  get; set; }
    }
}
