﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels;

public partial class ToDoStatus
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }

    public virtual ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();

    public virtual User UserCreated { get; set; }
}