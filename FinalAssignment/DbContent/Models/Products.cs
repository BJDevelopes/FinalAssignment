using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace FinalAssignment.Models
{
    [TableName("Products")]
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string instock { get; set; }
        public string pictureURL { get; set; }


    }
}