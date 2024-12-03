using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ContactChannel
{
    public long Id { get; set; }

    public string Value { get; set; }

    public string Remarks { get; set; }

    public long ContactChannelDescriptionId { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long? Contact_Id { get; set; }

    public bool UseForAppointmentEmails { get; set; }

    public virtual Contact Contact { get; set; }

    public virtual ContactChannelDescription ContactChannelDescription { get; set; }

    public virtual User UserCreated { get; set; }
}