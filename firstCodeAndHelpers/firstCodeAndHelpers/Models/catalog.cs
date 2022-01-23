using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstCodeAndHelpers.Models
{
    public class catalog
    {
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; }
        public string desc { get; set; }
        public virtual IList<news> News { get; set; }
    }
}