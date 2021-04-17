using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mvc_E_Ticaret_Proje.Models.Siniflar;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        //urun
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public ICollection<Urun> Uruns { get; set; }
        public ICollection<Cariler> Carilers { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}