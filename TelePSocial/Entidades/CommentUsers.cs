using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelePSocial.Entidades
{
    public class CommentUsers
    {
        [Key]
        public int idCommentUsers { get; set; }
        public string IdUser { get; set; }
        public int idPubliUsers { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FecComment { get; set; }
        public TimeSpan HorComment { get; set; }
        public string DesComment { get; set; }
        [NotMapped]
        public string usuario { get; set; }
        [NotMapped]
        public string username { get; set; }
        [NotMapped]
        public string desPhoto { get; set; }
        [NotMapped]
        public string photo { get; set; }
    }
}
