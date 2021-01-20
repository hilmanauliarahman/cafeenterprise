using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CafeApp.Win10.Models;

namespace CafeApp.Win10.ViewModels
{
    public class Dbconfig : DbContext
    {
        public DbSet<Menu> Cafeenterprise { get; set; }

    }
}