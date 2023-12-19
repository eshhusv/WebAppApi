using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAppApi.Models;

public partial class Acq
{
    public int IdAcq { get; set; }

    public int? IdClientWoman { get; set; }

    public int? IdClientMan { get; set; }

    public DateTime? Date { get; set; }

    public bool? WomanAgr { get; set; }

    public bool? ManAgr { get; set; }
    [JsonIgnore]
    public virtual Client? IdClientManNavigation { get; set; }
    [JsonIgnore]
    public virtual Client? IdClientWomanNavigation { get; set; }
}
