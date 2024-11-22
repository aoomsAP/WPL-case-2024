using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels
{
    public class ProspectionToDoes
    {
        [Key]
        public long Id { get; set; }

        public long ProspectionId { get; set; }

        public Prospection Prospection { get; set; }

        public long ToDoId { get; set; }

        public ToDo ToDo { get; set; }
    }
}
