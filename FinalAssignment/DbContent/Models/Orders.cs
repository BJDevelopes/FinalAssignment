using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace FinalAssignment.Models
{
    [TableName("Orders")]
    public class Orders
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public string quantity { get; set; }
        public string total { get; set; }
    }
}