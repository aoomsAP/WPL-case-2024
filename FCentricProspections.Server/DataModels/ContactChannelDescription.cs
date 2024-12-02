using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ContactChannelDescription
{
    public long Id { get; set; }

    public long ContactChannelTypeId { get; set; }

    public int Order { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual ContactChannelType ContactChannelType { get; set; }

    public virtual ICollection<ContactChannel> ContactChannels { get; set; } = new List<ContactChannel>();

    public virtual User UserCreated { get; set; }
}