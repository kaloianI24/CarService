 using CarService.Data.Entities;
using CarService.Models.AutoParts;

namespace CarService.Service.Interface
{
    public interface IAutoPartsService
    {
        void Add(CreateAutoPartsViewModel autoparts);

        IEnumerable<AutoPartsViewModel> GetAll();

        void Delete(int id);
        void Edit(EditAutoPartsViewModel autoParts);

        AutoPartsViewModel Get(int id);
    }
}
