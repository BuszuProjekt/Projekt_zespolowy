using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System_rezerwacji_biletów_w_Multikinie.Models
{
    public class Miejsce
    {
        public int ID { get; set; }
        public string Identyfikator { get; set; }
        public int IdSali { get; set; }
    }
}