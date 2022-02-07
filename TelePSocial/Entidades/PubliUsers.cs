using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelePSocial.Entidades
{
    public class PubliUsers
    {
        [Key]
        public int idPubliUsers { get; set; }
        public string IdUser { get; set; }
        public DateTime FecPublic { get; set; }
        public TimeSpan HorPublic { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)] 
        public string DesPublic { get; set; }
        [NotMapped]
        public string prop { get; set; }
    }
}
