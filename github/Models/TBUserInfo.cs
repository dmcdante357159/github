//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace github.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBUserInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name="username")]

        public string username { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="passwords")]
        [DataType(DataType.Password)]
        public string passwords { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "repasswords")]
        [DataType(DataType.Password)]
        [Compare("repasswords",ErrorMessage ="Confirm password doesn't match, type again!")]
        public string repasswords { get; set; }
    }
}
