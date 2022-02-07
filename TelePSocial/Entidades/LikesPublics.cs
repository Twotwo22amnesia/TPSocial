using System.ComponentModel.DataAnnotations;

namespace TelePSocial.Entidades
{
    public class LikesPublics
    {
        [Key]   
        public int idLikesPublics { get; set; }
        public string IdUser { get; set; }
        public int idPubliUsers { get; set; }
    }
}
