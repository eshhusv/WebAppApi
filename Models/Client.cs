using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAppApi.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Surename { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? City { get; set; }

    public string? Interest { get; set; }

    public string? Gender { get; set; }

    public bool? HasPair { get; set; }
    [JsonIgnore]
    public virtual ICollection<Acq> AcqIdClientManNavigations { get; set; } = new List<Acq>();
    [JsonIgnore]
    public virtual ICollection<Acq> AcqIdClientWomanNavigations { get; set; } = new List<Acq>();
    [JsonIgnore]
    public virtual ICollection<Pair> PairIdClientManNavigations { get; set; } = new List<Pair>();
    [JsonIgnore]
    public virtual ICollection<Pair> PairIdClientWomanNavigations { get; set; } = new List<Pair>();
}
