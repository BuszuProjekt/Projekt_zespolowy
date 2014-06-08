using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System_rezerwacji_biletów_w_Multikinie.Models
{
    public class Seans
    {
        public int ID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int IdFilmu { get; set; }
        public string TytułFilmu { get; set; }
        public int IdSali { get; set; }
        public DateTime Data { get; set; }
       
    }
}