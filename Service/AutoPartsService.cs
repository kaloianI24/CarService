using CarService.Data.Entities;
using CarService.Models.AutoParts;
using CarService.Repository.Interface;
using CarService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var autoPartsEntity = new AutoParts(autoparts.Name, autoparts.Price, autoparts.Stock);
            autoPartsRepository.Add(autoPartsEntity);
        }

        // Implement the method for getting all AutoParts
        public IEnumerable<AutoPartsViewModel> GetAll()
        {
            var autoPartsEntities = autoPartsRepository.GetAll();
            var autoParts = autoPartsEntities
                .Select(a => new AutoPartsViewModel(a.Id, a.Name, a.Price, a.Stock));
            return autoParts;
        }

        public AutoPartsViewModel Get(int id)
        {
            var autoParts = autoPartsRepository.Get(id);
            if (autoParts == null)
            {
                throw new KeyNotFoundException($"AutoPart with ID {id} not found.");
            }
            return new AutoPartsViewModel(autoParts.Id, autoParts.Name, autoParts.Price, autoParts.Stock);
        }

        public void Edit(EditAutoPartsViewModel autoParts)
        {
            var existingAutoParts = autoPartsRepository.Get(autoParts.Id);
            if (existingAutoParts == null)
            {
                throw new KeyNotFoundException($"AutoPart with ID {autoParts.Id} not found.");
            }

          
            existingAutoParts.Name = autoParts.Name;
            existingAutoParts.Price = autoParts.Price;
            existingAutoParts.Stock = autoParts.Stock;

           
            autoPartsRepository.Edit(existingAutoParts);
        }

        public void Delete(int id)
        {
            autoPartsRepository.Delete(id);
        }
    }
}
