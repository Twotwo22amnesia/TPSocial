using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelePSocial.Areas.Identity.Data;

namespace TelePSocial.Entidades
{
    public class PubliUsers
    {
        [Key]
        public int idPubliUsers { get; set; }
        public string IdUser { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)] 
        public DateTime FecPublic { get; set; }
        public TimeSpan HorPublic { get; set; }
        public string DesTitle { get; set; }
        public string DesPublic { get; set; }
        [NotMapped]
        public int CantiLikes { get; set; }
        [NotMapped]
        public bool CanLike { get; set; }
        [NotMapped]
        public ApplicationUser userpubli { get; set; }
        [NotMapped]
        public List<CommentUsers> Comentarios { get; set; } 
    }
}
