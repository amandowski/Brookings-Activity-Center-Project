using System;
using System.Collections.Generic;

namespace BACWebsite.Models
{
    public partial class MenuItem
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string AllergyWarning { get; set; }
        public string RecipeInstructions { get; set; }
        public decimal DishCost { get; set; }
        public string PicPath { get; set; }
    }
}
