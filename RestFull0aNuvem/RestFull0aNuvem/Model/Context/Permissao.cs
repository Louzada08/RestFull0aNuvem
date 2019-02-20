using RestFull0aNuvem.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFull0aNuvem.Model.Context
{
    [Table("Permissao")]
    public class Permissao : BaseEntity
    {
        [StringLength(60)]
        public string Titulo { get; set; }
        public bool Permitir { get; set; }
        public long? PermissaoParentId { get; set; }
    }
}
