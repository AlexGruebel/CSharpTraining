using System.ComponentModel.DataAnnotations;

namespace Exercies02
{
    public class Customer
    {
        
        [StringLength(4)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(40)]
        public string City { get; set; }
    }
}
