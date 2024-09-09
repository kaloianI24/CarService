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
        public int Price{ get; set; }
        [Required]
        public int Stock{ get; set; }

        


        public AutoParts(int id , string name, int price, int stock)
            :this (name , price, stock)
        {
            Id = id;
            
        }
        public AutoParts(string name , int price , int stock)
        {
             Name = name;
            Price = price;
            Stock = stock;

        }
    }
}
