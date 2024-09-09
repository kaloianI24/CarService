using CarService.Data.Entities;
using CarService.Repository.Interface;

namespace CarService.Repository
{
    public class AutoPartsRepository : IAutoPartsRepository

    {
        private readonly ApplicationContext context;

        public AutoPartsRepository(ApplicationContext context)
        {

            this.context = context; 


        }    
        

        public void Add(AutoParts autoparts)
        {
            context.AutoParts.Add(autoparts);
            context.SaveChanges();
        }

        public IEnumerable<AutoParts> GetAll()
        => context.AutoParts.ToList();

       
        public void Delete (int id)
        {
            var autoParts = Get(id);
            context.AutoParts.Remove(autoParts);
            context.SaveChanges();
        }
       public void Edit( AutoParts autoParts)
{
      var entity = Get(autoParts.Id);
       entity.Name = autoParts.Name;
    entity.Stock = autoParts.Stock;
    entity.Price = autoParts.Price;
    context.SaveChanges();
}

        public AutoParts Get(int id)
           => context.AutoParts.FirstOrDefault(autoParts => autoParts.Id == id);


    }
}
