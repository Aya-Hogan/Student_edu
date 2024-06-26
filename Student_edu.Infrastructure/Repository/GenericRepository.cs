﻿using Microsoft.EntityFrameworkCore;
using Student_edu.Core.DTO;
using Student_edu.Core.IRepositories;
using Student_edu.Infrastructure.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet =context.Set<T>();
        }

        public async Task<GenericResponse> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new GenericResponse { Success = true, Message = "Entity added successfully." };
        }

        public async Task<GenericResponse> Delete(T id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return new GenericResponse { Success = false, Message = "Entity not found." };
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new GenericResponse { Success = true, Message = "Entity removed successfully." };
        }
   

        public async Task<IEnumerable<T?>> GetAll()
        {
            return await _dbSet.ToListAsync();  
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<GenericResponse> Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return new GenericResponse { Success = true, Message = "Entity updated successfully." };
        }
    }
}
