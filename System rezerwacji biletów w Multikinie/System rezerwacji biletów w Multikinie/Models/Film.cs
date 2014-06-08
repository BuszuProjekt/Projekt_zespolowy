using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace System_rezerwacji_biletów_w_Multikinie.Models
{
    public class Film
    {
        public int ID { get; set; }
        [Required]
        [StringLength(32)]
        public string Tytul  { get; set; }
        [Required]
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

    }
}