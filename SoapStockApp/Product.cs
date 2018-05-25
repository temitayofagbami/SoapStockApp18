using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{


    public enum TypeOfProduct

    {
        [Display(Name = "Laundry_Detergent")]

        Laundry_Detergent,

        [Display(Name = "Bar")]
        Bar,
        [Display(Name = "Dish")]
        Dish,
        [Display(Name = "Body_Wash")]
        Body_Wash,

    }


   public class Product
    {

/// <summary>
/// 
/// </summary>
        private static int lastProductID = 0;
        #region Properties
        [Key]
        
        public int ProductID { get; private set; }

        [Required]
        [StringLength(30,ErrorMessage = "Product Name cannot be more than 30 characters in length")]
        public string  ProductName { get;  set; }

        [Required]
        [StringLength(30, ErrorMessage = "Product Supplier cannot be more than 30 characters in length")]
        public string ProductSupplierName { get; set; }

      //  [Required]
       // [StringLength(30, ErrorMessage = "Product Decription cannot be more than 100 characters in length")]
        public string ProductDescr { get;set; }

        [EnumDataType(typeof(TypeOfProduct),   ErrorMessage = " Must choose from List of Soap type")]
        // must be only ther four 
        public TypeOfProduct ProductType { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Please enter price")]
        public decimal ProductPrice { get; private set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Please enter valid Number")]
        public int ProductQuantity { get; set; }
       

      //  public virtual ICollection<Order> Orders { get; set; }
        #endregion


        #region Constructor
        public Product()
        {
            ProductID = ++lastProductID;

        }
        #endregion
        #region Methods
        //these will be called by store owner, not customer
        public void AddProductName(string value)
    {
        ProductName = value;

    }
        public void AddProductDescr(string value)
        {
            ProductDescr = value;

        }
        public void AddProductType(TypeOfProduct value)
        {
            ProductType = value;

        }
        public void SetProductPrice(decimal value)
        {
            ProductPrice = value;

        }
       
        public void IncrementProductQuantity(int value)
        {
            ProductQuantity += value;

        }
        public void DecrementProductQuantity(int value)
        {
            ProductQuantity -= value;

        }
        #endregion
    }
}
