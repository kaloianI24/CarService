using CarService.Data.Entities;
using CarService.Models.AutoParts;
using CarService.Repository.Interface;
using CarService.Service.Interface;


namespace CarService.Service
{
    public class AutoPartsService : IAutoPartsService
    {
        private readonly IAutoPartsRepository autoPartsRepository;

        public AutoPartsService(IAutoPartsRepository autoPartsRepository)
        {
            this.autoPartsRepository = autoPartsRepository;
        }

        public void Add(CreateAutoPartsViewModel autoparts)
        {
            var autoPartsEntities = new AutoParts(autoparts.Name, autoparts.Price, autoparts.Stock);
            autoPartsRepository.Add(autoPartsEntities);
        }

        public IEnumerable<AutoParts> GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<AutoPartsViewModel> IAutoPartsService.GetAll()
        {
            var autoPartsEntities = autoPartsRepository.GetAll();
            var autoParts = autoPartsEntities
                .Select(autoParts => new AutoPartsViewModel(autoParts.Id, autoParts.Name, autoParts.Price, autoParts.Stock));

            return autoParts;
        }


        public AutoPartsViewModel Get (int id)
        {

            var autoParts = autoPartsRepository.Get(id);

            return new AutoPartsViewModel(autoParts.Id, autoParts.Name, autoParts.Price, autoParts.Stock);
        }

      public void Edit(EditAutoPartsViewModel autoParts)
        {
            var autoPartsEntity = new AutoParts(autoParts.Id, autoParts.Name, autoParts.Stock, autoParts.Stock  );
            autoPartsRepository.Add(autoPartsEntity);
        }

        public void Delete(int id)
            =>autoPartsRepository.Delete(id);



        
    }
}
