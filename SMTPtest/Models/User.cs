using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMTPtest.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Carrier { get; set; }
    }
}