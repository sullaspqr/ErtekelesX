using System;
using System.Collections.Generic;

#nullable disable

namespace ErtekelesX.Models
{
    public partial class Getter
    {
        public string Nev { get; set; }
        public int Pontertek { get; set; }
        public int Szorzo { get; set; }
        public string SzempontNev { get; set; }
        public long VégsőPont { get; set; }
    }
}
