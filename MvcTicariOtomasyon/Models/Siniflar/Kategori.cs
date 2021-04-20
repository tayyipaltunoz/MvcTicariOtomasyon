using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}