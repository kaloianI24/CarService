using System.ComponentModel.DataAnnotations;

namespace CarService.Data.Entities
{
    public class AutoParts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double Price{ get; set; }
        [Required]
        public int Stock{ get; set; }

        


        public AutoParts(int id , string name, double price, int stock)
            :this (name , price, stock)
        {
            Id = id;
            
        }
        public AutoParts(string name , double price , int stock)
        {
             Name = name;
            Price = price;
            Stock = stock;

        }
    }
}
