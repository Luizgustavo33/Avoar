using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agence3.Models
{
    [Table("CadPromocoes")]

    public class Promoções
    {
      
            [Key]
            [Column("IDcontato")]
            [Display(Name = "ID")]
            [Required]
            public int IDPromoc{ get; set; }



        public int IDviagem { get; set; }

        [ForeignKey("IDviagem")]


        public virtual Viagem Viagem { get; set; }


        [Column("Preço")]
        [Display(Name = "Preço viagem com desconto")]
        [Required]
        public decimal Preço_desconto { get; set; }

    }
    }