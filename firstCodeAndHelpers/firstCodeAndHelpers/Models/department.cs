using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstCodeAndHelpers.Models
{
    public class department
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<user> users { get; set; }
    }
}