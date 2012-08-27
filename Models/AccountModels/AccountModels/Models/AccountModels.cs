using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using System.Web.Profile;


namespace login.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasenya actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} ha de tenir al menys una longitud de {2} caràcters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasenya nova")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova contrasenya")]
        [Compare("NewPassword", ErrorMessage = "La nova contrasenya i la confirmación no son iguals.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class CustomProfile : ProfileBase
    {
        public static CustomProfile GetUserProfile(string username)
        {
            return Create(username) as CustomProfile;
        }


        [SettingsAllowAnonymous(false)]
        public string Nom
        {
            get { return base["Nom"] as string; }
            set { base["Nom"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string PCognom
        {
            get { return base["PCognom"] as string; }
            set { base["PCognom"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string SCognom
        {
            get { return base["SCognom"] as string; }
            set { base["SCognom"] = value; }
        }

    }

    public class CustomProfileViewModel
    {
        [Display(Name = "Nom")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Display(Name = "Primer Cognom")]
        [DataType(DataType.Text)]
        public string PCognom { get; set; }

        [Display(Name = "Segon Cognom")]
        [DataType(DataType.Text)]
        public string SCognom { get; set; }

    }
}

