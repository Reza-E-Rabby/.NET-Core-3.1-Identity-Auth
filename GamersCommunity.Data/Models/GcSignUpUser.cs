using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamersCommunity.Data.Models
{
    public class GcSignUpUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Your Password")]
        [Compare("Password",
            ErrorMessage = "Please Recheck Your Password!")]
        public string ConfirmPassword { get; set; }
    }
}
