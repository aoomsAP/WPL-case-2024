namespace FCentricProspections.Server.DomainModels
{
    public class UserDto
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public bool Blocked { get; set; }

        public ICollection<ProspectionDetailDto> Prospections { get; set; }
    }
}
