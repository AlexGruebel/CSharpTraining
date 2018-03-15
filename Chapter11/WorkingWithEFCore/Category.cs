using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Packt.CS7{
    public class Category{

        //Properties die mit der DB gemapped werden
        //Anfang
        public int CategoryID{get;set;}
        public string CategoryName{get;set;}
        
        [Column(TypeName="NText")]
        public string Description{get;set;}
        //Ende

        //Navigations property für relevante Zeile
        public virtual ICollection<Product> Products{get; set;}

        public Category()
        {
        // initialize the navigation property 
        // jetzt können Devolopers Produkte zu der Categorie hinzufügen
        this.Products = new List<Product>();
        }
    }
}