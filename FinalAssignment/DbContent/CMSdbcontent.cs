using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FinalAssignment.Models;

namespace FinalAssignment.DbContent
{
    public class CMSdbcontent : System.Data.Entity.DbContext
    {
        DbSet<Users> Users { get; set; }

        DbSet<Products> Products { get; set; }
    }
}