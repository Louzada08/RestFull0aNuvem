using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFull0aNuvem.Model.Context
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public long Idpk    { get; set; }
        [StringLength(100)]
        public string Nome  { get; set; }
        [StringLength(100)]
        public string Login { get; set; }
        [StringLength(15)]
        public string Senha { get; set; }
    }
}
