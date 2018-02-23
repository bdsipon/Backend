using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Para
    {
        [Key]
        public int ParaId { get; set; }
        public string ParaText { get; set; }
    }
}
