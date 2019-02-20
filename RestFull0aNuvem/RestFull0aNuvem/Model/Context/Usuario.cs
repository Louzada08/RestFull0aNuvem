using RestFull0aNuvem.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFull0aNuvem.Model.Context
{
    [Table("Usuario")]
    public class Usuario : BaseEntity
    {
       // [Key]
       // public long Id    { get; set; }
        [StringLength(100)]
        public string Nome  { get; set; }
        [StringLength(100)]
        public string Login { get; set; }
        [StringLength(15)]
        public string Senha { get; set; }
    }
}
