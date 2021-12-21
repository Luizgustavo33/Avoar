    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agence3.Models
{
    [Table("CadContato")]
    public class Contato
    {
        [Key]
        [Column("IDcontato")]
        [Display(Name = "ID")]
        [Required]

        public int IDcontato { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Email")]
        [Required]

        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }



    }
}