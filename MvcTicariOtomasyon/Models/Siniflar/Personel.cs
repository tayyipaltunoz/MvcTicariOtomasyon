﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public  int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}