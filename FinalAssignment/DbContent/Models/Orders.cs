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
        public string userID { get; set; }
        public string productID { get; set; }
        public int total { get; set; }
    }
}