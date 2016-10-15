//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Order = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="不接受 10 個字以上")]
        [DisplayName("名字")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(5)]
        [Display(Name = "中間名")]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(10)]
       
        public string LastName { get; set; }
        [Required]
        [RegularExpression("[MF]")]
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<double> CreditRating { get; set; }
        public string XCode { get; set; }
        public Nullable<int> OccupationId { get; set; }
        public string TelephoneNumber { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string Notes { get; set; }
    
        public virtual Occupation Occupation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
