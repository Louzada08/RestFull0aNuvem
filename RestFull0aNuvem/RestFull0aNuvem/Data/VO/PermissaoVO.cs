using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestFull0aNuvem.Data.VO
{
    [DataContract]
    public class PermissaoVO
    {
        [DataMember(Order = 1)]
        public long Id { get; set; }
        [StringLength(60)]
        [DataMember(Order = 2, IsRequired = true)]
        public string Titulo { get; set; }
        [DataMember(Order = 3)]
        public bool Permitir { get; set; }
        [DataMember(Order = 4)]
        public long? PermissaoParentId { get; set; }
        public ICollection<PermissaoVO> PermisaoParentVO { get; set; }
    }
}
