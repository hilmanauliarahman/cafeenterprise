using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeApp.Win10.Models
{
    public class Jenis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_jenis { get; set; }
        [Required]
        [MinLength(5), MaxLength(100)]
        public string nama_jenis { get; set; }
    }
}
