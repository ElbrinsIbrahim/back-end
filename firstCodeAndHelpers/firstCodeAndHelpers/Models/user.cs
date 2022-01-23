using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstCodeAndHelpers.Models
{
    public class user
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
      [Display(Name ="user_id")]
        public int id { get; set; }
        [Required (ErrorMessage ="*")]
        [Display(Name ="fullname")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="short name")]
        public string name { get; set; }
        [Required(ErrorMessage = "*")]
        [Range (20,60,ErrorMessage ="age must between 20 and 60")]
        public int age { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression (@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",ErrorMessage ="invaid email")]
        public string email { get; set; }
        public string password { get; set; }
        [NotMapped]
        [Compare("password",ErrorMessage ="password not match")]
        public string confirmpassword { get; set; }
        public string photo { get; set; }

        public virtual List<news> News  { get; set; }
        [ForeignKey("Department")]
        public int? dept_id { get; set; }
        public virtual department Department { get; set; }

    }
}