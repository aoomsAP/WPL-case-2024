﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ToDo
{
    public long Id { get; set; }

    public string Remarks { get; set; }

    public long? EmployeeId { get; set; }

    public long ToDoStatusId { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ToDoStatus ToDoStatus { get; set; }

    public virtual User UserCreated { get; set; }

    public ICollection<ProspectionToDo> ProspectionToDos { get; set; }
}