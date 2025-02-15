﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels;

public partial class ToDo
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public string Remarks { get; set; }

    public long ToDoTypeId { get; set; }

    public long ToDoStatusId { get; set; }

    public virtual ToDoType ToDoType { get; set; }

    public virtual ToDoStatus ToDoStatus { get; set; }

    public ICollection<ToDoEmployee> ToDoEmployees { get; set; } = new List<ToDoEmployee>();

    public ICollection<ProspectionToDo> ProspectionToDos { get; set; } = new List<ProspectionToDo>();

    public long UserCreatedId { get; set; }

    public virtual User UserCreated { get; set; }

    public DateTime DateCreated { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }
}