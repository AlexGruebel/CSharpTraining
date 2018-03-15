using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Exercies02
{
    public class Product : IToCsv{
         
         public int ProductID {get;set;}
         
         [Required]
         [StringLength(40)]
         public string ProductName {get;set;}

         public int SupplierID{get;set;}

         public int CategoryID{get;set;}

         [StringLength(20)]
         public string QuantityPerUnit{get;set;}

         [Column(TypeName="money")]
         public decimal UnitPrice{get;set;}

         [Column(TypeName="smallint")]
         public short UnitsInStock{get;set;}

         [Column(TypeName="smallint")]
         public short ReorderLevel{get;set;}


         [Required]
         [Column(TypeName="bit")]
         public bool Discontinued{get;set;}

        public string HeadLine => "ProductID;ProductName;SupplierID;CategoryID;QuantityPrice;UnitPrice;RecordLevel;Discontinued";

        public string ToCsv()
        {
            return
            $"{this.ProductID};{this.ProductName};{this.SupplierID};" +
            $"{this.CategoryID};{this.QuantityPerUnit};{this.UnitPrice};"+ 
            $"{this.ReorderLevel};{this.Discontinued}";
        }

        public override string ToString(){
             return "Product";
         }


    }
}