using System;
using System.ComponentModel.DataAnnotations;

namespace TelePSocial.Entidades
{
    public class LogSes
    {
        [Key]
        public int idLogSes { get; set; }

        [Display(Name = "Usuario Conexión")]
        public string IdUser { get; set; }

        [Display(Name = "Fecha Sesion")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FecLogeo { get; set; }

        [Display(Name = "Hora Sesion ")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan HorLogeo { get; set; }

        [Display(Name = "Estado")]
        public bool EstLogeo { get; set; }
    }
}
