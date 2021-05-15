using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karekter yazabilirsiniz")]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariUnvan { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CariTelefon { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}