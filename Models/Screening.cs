using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace ErtekelesX.Models
{
    public partial class Screening
    {
        public Screening()
        {
            Ertekeleseks = new HashSet<Ertekelesek>();
        }

        public int Id { get; set; }
        public string Nev { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ertekelesek> Ertekeleseks { get; set; }
    }
}
