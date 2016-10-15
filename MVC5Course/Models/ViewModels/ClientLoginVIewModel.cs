using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientLoginViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "不接受 10 個字以上")]
        [DisplayName("名字")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(5)]
        [Display(Name = "中間名")]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(10)]

        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}