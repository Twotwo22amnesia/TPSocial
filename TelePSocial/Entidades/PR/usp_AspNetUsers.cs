using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelePSocial.Entidades.PR
{
    public class usp_AspNetUsers
    {
        [Key]
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhotoPerfil { get; set; }
        [NotMapped]
        [Display(Name = "Adjunto")]
        public string DesImage { get { return string.Format("~/images/Photos/{0}", PhotoPerfil); } }
        [NotMapped]
        [PersonalData]
        public string Nombre_Usuario
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
