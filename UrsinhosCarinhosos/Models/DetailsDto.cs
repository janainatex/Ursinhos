using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrsinhosCarinhosos.Models
{
    public class DetailsDto
    {
        public Ursinhos Prior {get; set; }
        public Ursinhos Current { get ; set;}
        public Ursinhos Next { get; set ;}
        public List<Tipo> Tipos { get; set;}
        
    }
}