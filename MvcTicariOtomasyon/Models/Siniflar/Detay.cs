using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int detayId { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(50)]
        public string urunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string urunBilgi { get; set; }
    }
}