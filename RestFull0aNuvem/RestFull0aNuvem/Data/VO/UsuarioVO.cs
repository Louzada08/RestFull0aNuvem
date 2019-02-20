using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestFull0aNuvem.Data.VO
{
    [DataContract]
    public class UsuarioVO
    {
        [DataMember(Order = 1)]
        public long Id { get; set; }
        [StringLength(100)]
        [DataMember(Order = 2, IsRequired = true)]
        public string Nome  { get; set; }
        [StringLength(100)]
        [DataMember(Order = 3)]
        public string Login { get; set; }
        [StringLength(15)]
        [DataMember(Order = 4)]
        public string Senha { get; set; }
    }
}
