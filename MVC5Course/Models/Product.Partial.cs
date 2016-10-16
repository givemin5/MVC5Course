namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.ProductName.Contains("Black"))
            {
                yield return new ValidationResult("不雅字眼", new string[] { "ProductName" });
            }

            if (this.Price > 10000000)
            {
                yield return new ValidationResult("不合理價格", new string[] { "Price" });
            }
            if (this.Stock >0 && this.IsDeleted)
            {
                yield return new ValidationResult("下架前請先清空庫存數量", new string[] { "Stock", "IsDeleted" });
            }
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        [Range(0,1000)]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
