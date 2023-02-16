using System;
using System.Collections.Generic;

#nullable disable

namespace ErtekelesX.Models
{
    public partial class Ertekelesek
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public int SzempontId { get; set; }
        public int Pontertek { get; set; }

        public virtual Screening Screening { get; set; }
        public virtual Szempont Szempont { get; set; }
    }
}
