﻿using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Exceptions;
using AnimalSpawn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Application.Services
{
    public class AnimalService : IAnimalServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _Max_Register_Day = 5;

        public AnimalService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddAnimal(Animal animal)
        {
            Expression<Func<Animal, bool>> exprAnimal = item => item.Name == animal.Name;
            var animals = _unitOfWork.AnimalRepository.FindByCondition(exprAnimal);
            if (animals.Any())
                throw new BusinessException("This animal name already exist.");
            if (animal?.EstimatedAge > 0 && (animal?.Weight <= 0 || animal?.Height <= 0))
                throw new BusinessException("The height and weight should be greater than zero.");
            var older = DateTime.Now - (animal?.CaptureDate?.Date ?? DateTime.Now);
            if (older.TotalDays > _Max_Register_Day)
                throw new BusinessException("The animl's capture date is older than 45 days.");

            if(animal.RfidTag != null)
            {
                Expression<Func<RfidTag, bool>> exprTag = item => item.Tag == animal.RfidTag.Tag;
                var tags = _unitOfWork.RFidTagRepository.FindByCondition(exprTag);
                if (tags.Any()) throw new BusinessException("This animal's tag rdig already exist.");
            }
            await _unitOfWork.AnimalRepository.Add(animal);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAnimal(int id)
        {
            await _unitOfWork.AnimalRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _unitOfWork.AnimalRepository.GetById(id);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _unitOfWork.AnimalRepository.GetAll();
        }

        public async Task  UpdateAnimal(Animal animal)
        {
            _unitOfWork.AnimalRepository.Update(animal);
            await _unitOfWork.SaveChangesAsync();
        }
     
    }
}
