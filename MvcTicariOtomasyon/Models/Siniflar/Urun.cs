using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int CategoryId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}