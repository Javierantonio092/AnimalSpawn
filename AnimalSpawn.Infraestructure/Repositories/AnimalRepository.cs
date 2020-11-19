using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalSpawn.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly AnimalSpawnContext _context;
        public AnimalRepository(AnimalSpawnContext context)
        {
            this._context = context;
        }    

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var animals = await _context.Animals.ToListAsync();
            return animals; 
        }

        public async Task<Animal> GetAnimal(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(animal => animal.Id == id);
            return animal;
        }

        public async Task AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAnimal(Animal animal)
        {
            var current = await GetAnimal(animal.Id);

            current.GenusId = animal.GenusId;
            current.UpdateAt = DateTime.Now;
            current.UpdatedBy = 5;
            current.FamilyId = animal.FamilyId;
            current.Description = animal.Description;
            current.EstimatedAge = animal.EstimatedAge;
            current.Gender = animal.Gender;
            current.Height = animal.Height;
            current.Name = animal.Name;
            current.Photos = animal.Photos;
            current.SpeciesId = animal.SpeciesId;

            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            var current = await GetAnimal(id);
            _context.Animals.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();

            return rowsDelete > 0;
        }
    }
}
