using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace TelePSocial.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "¿Activo?")]
        public bool IsEnabled { get; set; }
        [Display(Name = "Nombres")]
        [NotMapped]
        [PersonalData]
        public string Nombre_Usuario
        {
            get
            { 
                    return FirstName + " " + LastName; 
            }
        }   
        [Display(Name = "Foto de perfil")]
        public string PhotoPerfil { get; set; }
        [NotMapped]
        [Display(Name = "Adjunto")]
        public string DesImage { get { return string.Format("~/images/Photos/{0}", PhotoPerfil); } }
        [PersonalData]
        [Display(Name = "Género")]
        public string Gender { get; set; }
        [NotMapped]
        [Display(Name = "Género")]
        public string DesGender
        { 
            get
            {
                if (Gender.Equals("F"))
                {
                return "Femenino";

                }
                if (Gender.Equals("M"))
                {
                    return "Masculino";

                }
                else
                {
                    return "Otros";

                }
            }
        }
        [Display(Name = "Fecha de Cumpleaños")]
        [DataType(DataType.Date)] 
        public DateTime BirthDay { get; set; }
        [Display(Name = "Apellidos")]
        [PersonalData]
        public string LastName { get; set; }
        [Display(Name = "Nombres")]
        [PersonalData]
        public string FirstName { get; set; }
        [NotMapped]
        public IFormFile DOC_DOCUM { get; set; }
    }
}
