﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MobileShop.Model.Models
{
    public class Artikli
    {
        public int ArtikalId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public bool? Status { get; set; }
        public int KarakteristikeId { get; set; }
        public int ModelId { get; set; }
        public int ProizvodjacId { get; set; }


    }
}
