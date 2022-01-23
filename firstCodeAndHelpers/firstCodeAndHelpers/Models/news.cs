using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstCodeAndHelpers.Models
{
    public class news
    {
        public int id { get; set; }
        public string title { get; set; }
        public string bref { get; set; }
        public string desc { get; set; }
        public DateTime date { get; set; }
        public string photo { get; set; }
        [ForeignKey ("news_user")]
        public int? user_id { get; set; }
     
        [ForeignKey("news_Catalog")]
        public int? cat_id { get; set; }
        public virtual user news_user { get; set; }
        public virtual catalog news_Catalog { get; set; }
    }
}