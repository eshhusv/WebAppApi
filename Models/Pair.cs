using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAppApi.Models;

public partial class Pair
{
    public int IdPair { get; set; }

    public int? IdClientWoman { get; set; }

    public int? IdClientMan { get; set; }

    public bool? Status { get; set; }

    public DateOnly? Date { get; set; }
    [JsonIgnore]
    public virtual Client? IdClientManNavigation { get; set; }
    [JsonIgnore]
    public virtual Client? IdClientWomanNavigation { get; set; }
}
