﻿using EasyDriveRentals.Domain.Interfaces;
using EasyDriveRentals.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyDriveRentals.Infrastructure.Repositorys
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly AutoRentalDBContext _dbContext;

        public GenericRepository(AutoRentalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> GetEverythingAsync(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw;
            }

        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;

            }

        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }
        public async Task<TModel> GetByIdAsync(int id)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FindAsync(id);
                return model;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> DeleteAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }

        public async Task<IQueryable<TModel>> VerifyDataExistenceAsync(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> ModelQuery = filter == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
                return ModelQuery;
            }
            catch
            {
                throw;
            }

        }

    }
}
