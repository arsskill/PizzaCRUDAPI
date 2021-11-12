using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaCRUDAPI.Models
{
    public class Pizza
    {
        [Key]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Acrive { get; set; }
        public string New { get; set; }
        public string Listofingredients { get; set; }
        public string Typeofdough { get; set; }
        public string Typeofadditionalingredients { get; set; }
    }
}
