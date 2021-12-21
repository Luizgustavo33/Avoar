using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agence3.Models
{
    [Table("CadViagem")]
    public class Viagem
    {
       
        [Key]

        [Column("IDviagem")]
        [Display(Name = "ID")]
        [Required]
        public int IDviagem { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Embarque")]
        [Required]
        public string Embarque { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Destino")]
        [Required]
        public string Destino { get; set; }

        [Display(Name = "Data_Embarque")]
        [Required]
        public string Data_Embarque { get; set; }

        [Column("Preço")]
        [Display(Name = "Preço viagem")]
        [Required]
        public decimal Preço { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<Promoções> Promoções { get; set; }


    }
}
