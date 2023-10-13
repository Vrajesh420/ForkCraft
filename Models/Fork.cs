using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForkCraft.Models
{
    public class Fork
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public string Finishing { get; set; }
        public string HandleDesign { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
