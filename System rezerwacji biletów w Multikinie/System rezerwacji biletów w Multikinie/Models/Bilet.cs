using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System_rezerwacji_biletów_w_Multikinie.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public int IdUsera { get; set; }
        public int IdSeansu { get; set; }
        public int IdMiejsca { get; set; }
        public decimal Cena { get; set; }

    }
}