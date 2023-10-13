using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForkCraft.Models
{
    public class ForkMaterialViewModel
    {
         public List<Fork> Forks
        { get; set; }
        public SelectList Material { get; set; }
        public string ForkMaterial { get; set; }
        public string SearchString { get; set; }
    }
}
