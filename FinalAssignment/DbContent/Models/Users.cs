using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalAssignment.Models
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; } 
        public string isadmin { get; set; }
        
        [Required(ErrorMessage = "Please Enter Username")]
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }
}