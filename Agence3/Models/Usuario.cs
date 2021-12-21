using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agence3.Models
{
    [Table("CadUsuario")]

    public class Usuario
    {
        [Key]
        [Column("IDusuario")]
        [Display(Name = "ID")]
        [Required]

        public int ID { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("Idade")]
        [Display(Name = "Idade")]
        [Required]
        public int Idade { get; set; }

        [Display(Name = "CPF")]
        [Required]
        public string CPF { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Endereco")]
        [Required]
        public string Endereco { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

    
        [Required]
        public int IDviagem { get; set; }

        [ForeignKey("IDviagem")]


        public virtual Viagem Viagem { get; set; }



    }
}