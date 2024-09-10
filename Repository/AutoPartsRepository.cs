using CarService.Data.Entities;
using CarService.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Repository
{
    public class AutoPartsRepository : IAutoPartsRepository
    {
        private readonly ApplicationContext context;

        public AutoPartsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(AutoParts autoParts)
        {
            context.AutoParts.Add(autoParts);
            context.SaveChanges();
        }

        public IEnumerable<AutoParts> GetAll()
        => context.AutoParts.ToList();

        public void Delete(int id)
        {
            var autoParts = Get(id);
            if (autoParts != null)
            {
                context.AutoParts.Remove(autoParts);
                context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"AutoPart with ID {id} not found.");
            }
        }

        public void Edit(AutoParts autoParts)
        {
            var existingEntity = context.AutoParts.Find(autoParts.Id);
            if (existingEntity != null)
            {
                existingEntity.Name = autoParts.Name;
                existingEntity.Price = autoParts.Price;
                existingEntity.Stock = autoParts.Stock;
                context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"AutoPart with ID {autoParts.Id} not found.");
            }
        }

        public AutoParts Get(int id)
           => context.AutoParts.FirstOrDefault(autoParts => autoParts.Id == id);
    }
}
