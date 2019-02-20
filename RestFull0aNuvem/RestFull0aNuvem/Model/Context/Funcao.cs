using RestFull0aNuvem.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFull0aNuvem.Model.Context
{
    [Table("Funcao")]
    public class Nullable : BaseEntity
    {
        [StringLength(30)]
        [Required]
        public string Descricao { get; set; }
        [Range(0.000,50000.000)]
        [RegularExpression(@"^\d+.\d{9,3}$")]
        public decimal SalarioBase { get; set; }
        [MaxLengthAttribute]
        [Required(AllowEmptyStrings = true)]
        public string Permissoes { get; set; }
    }
}
