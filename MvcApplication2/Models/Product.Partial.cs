namespace MvcApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        // 模型驗證, 在輸入驗證後執行

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price < 10000)
            {
                yield return new ValidationResult("Price is too low", new string[] { "Price" });
            }

            if (ProductName.Length < 5)
            {
                yield return new ValidationResult("ProductName is too short", new string[] { "ProductName" });
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
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
