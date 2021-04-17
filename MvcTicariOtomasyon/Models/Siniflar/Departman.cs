using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_E_Ticaret_Proje.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public int DepartmanAd { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}