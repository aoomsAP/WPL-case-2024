﻿namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionToDoGetViewModel
    {
        public long? Id { get; set; }

        public long ProspectionId { get; set; }

        public long ToDoId { get; set; }

        public string Name { get; set; }

        public string Remarks { get; set; }

        public long? ToDoTypeId { get; set; }

        public string? ToDoType { get; set; }

        public long? ToDoStatusId { get; set; }

        public string? ToDoStatus { get; set; }
    }

    public class ProspectionToDoUpdateViewModel
    {
        public IEnumerable<long> ToDoIds { get; set; }
    }
}
