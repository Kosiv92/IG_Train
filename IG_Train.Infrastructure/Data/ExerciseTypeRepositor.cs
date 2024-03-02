﻿using IG_Train.Domain.Entities;
using IG_Train.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IG_Train.Infrastructure.Data
{
    public class ExerciseTypeRepository : IRepository<ExerciseType>
    {
        ApplicationDbContext _context;
        DbSet<ExerciseType> _exerciseTypes;

        public ExerciseTypeRepository(ApplicationDbContext context)
        {
            _context = context;
            _exerciseTypes = _context.ExerciseTypes;
        }

        public async Task<int> CreateAsync(ExerciseType entity)
        {
            await _exerciseTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _exerciseTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new Exception($"ExerciseType with ID:{id} not found");

            _exerciseTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseType>> GetAllAsync()
        {
            return await _exerciseTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ExerciseType?> GetByIdAsync(int id)
        {
            return await _exerciseTypes
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
