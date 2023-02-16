using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace ErtekelesX.Models
{
    public partial class Szempont
    {
        public Szempont()
        {
            Ertekeleseks = new HashSet<Ertekelesek>();
        }

        public int Id { get; set; }
        public string SzempontNev { get; set; }
        public int Szorzo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ertekelesek> Ertekeleseks { get; set; }
    }
}
