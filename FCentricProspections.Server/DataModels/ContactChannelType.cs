﻿using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ContactChannelType
{
    public long Id { get; set; }

    public string ValidationRegex { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual ICollection<ContactChannelDescription> ContactChannelDescriptions { get; set; } = new List<ContactChannelDescription>();

    public virtual User UserCreated { get; set; }
}