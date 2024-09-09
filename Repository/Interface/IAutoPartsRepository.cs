using CarService.Data.Entities;
using CarService.Models;
using CarService.Models.AutoParts;


namespace CarService.Repository.Interface
{
    public interface IAutoPartsRepository
    {

        void Add(AutoParts autoparts);

        IEnumerable<AutoParts> GetAll();


        void Delete (int Id);

        void Edit(AutoParts autoParts);
        AutoParts Get(int id);
    }
}
