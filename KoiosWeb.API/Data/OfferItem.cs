﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiosWeb.API.Data;

public partial class OfferItem
{
    public int Id { get; set; }

    public int OfferId { get; set; }

    public int ComputerHardwareId { get; set; }

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public virtual ComputerHardware ComputerHardware { get; set; }

    public virtual Offer Offer { get; set; }
}