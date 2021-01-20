using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Win10.Models
{
    
   public class Transaksi
    {
        public int id_transaksi { get; set; }

        public string nama { get; set; }
        public int jumlah { get; set; }
        public int harga_jual { get; set; }

        public decimal diskonpersen { get; set; }

        public decimal Total()
        {
            decimal total = jumlah * harga_jual;
            return total - (diskonpersen / 100 * total);
            
        }
        public decimal total { get; set; }
    }
}
