using CarService.Service;

namespace CarService.Models.AutoParts
{
    public class EditAutoPartsViewModel
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public double Price { get; set; }
        public int  Stock { get; set; }
    }

}
