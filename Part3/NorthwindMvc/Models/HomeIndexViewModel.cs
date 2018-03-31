using System.Collections.Generic;
using NorthwindContextLib;
using NorthwindEntitiesLib;

namespace NorthwindMvc.Models
{
    public class HomeIndexViewModel
    {
        public int VisitorCount;
        public IList<Category> Categories {get;set;}
    }
}