using AnimalSpawn.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IAnimalServices
    {
        public IEnumerable<Animal> GetAnimals();
        public Task<Animal> GetAnimal(int id);
        public Task AddAnimal(Animal animal);
        public Task UpdateAnimal(Animal animal);
        public Task DeleteAnimal(int id);
    }
}
