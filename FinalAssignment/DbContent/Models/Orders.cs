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
    [Table("Orders")]
    public class Orders
    {
        public int Id { get; set; }      
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
        public string products { get; set; }
        public string hasshipped { get; set; }
    }

}