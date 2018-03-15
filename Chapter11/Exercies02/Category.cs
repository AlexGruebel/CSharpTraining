using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercies02{
    public class Category : IToCsv{

        public int CategoryID {get;set;}
        
        [StringLength(15)]
        public string CategoryName{ get; set; }

        [Column(TypeName="Text")]
        public string Description{get;set;}

        public string HeadLine => "CategoryID;CategoryName;Description";

        public string ToCsv()
        {
            return $"{this.CategoryID};{this.CategoryName};{this.Description}";
        }

        public override string ToString(){
            return "Category";
        }
    }
}