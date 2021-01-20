using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CafeApp.Win10.Models
{
    [Table("Menu")]
    public class Menu
    {

        [Key]
        public int id_menu { get; set; }

        
        public string nama { get; set; }
        public int id_jenis { get; set; }
        public string komposisi { get; set; }
        public float harga_pokok { get; set; }
        public float harga_jual { get; set; }
        public string status { get; set; }
    }
}
