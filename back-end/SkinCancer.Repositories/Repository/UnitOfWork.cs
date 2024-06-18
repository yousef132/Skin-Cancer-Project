﻿using SkinCancer.Entities.Models;
using SkinCancer.Repositories.Interface;
using SkinCancer.Entities;
using System.Collections;

namespace SkinCancer.Repositories.Repository
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private Hashtable repositories;

        public IScheduleRepository scheduleRepository { get; set;}
        public IDetectionRepository detectionRepositoty { get; set;}
        public IClinicRepository clinicRepository { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            this.scheduleRepository = new ScheduleRepository(context);
            this.detectionRepositoty = new DetectionRepository(context);
            this.clinicRepository = new ClinicRepository(context);
        }

        public async Task<int> CompleteAsync() => await context.SaveChangesAsync();

        public IGenericRepository<TEntity> Reposirory<TEntity>() where TEntity : BaseEntity
        {

            if (repositories == null)
                repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name;
            if (!repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInsatnce = Activator.CreateInstance
                    (repositoryType.MakeGenericType(typeof(TEntity)), context);

                repositories.Add(entityKey, repositoryInsatnce);
            }
            return (IGenericRepository<TEntity>)repositories[entityKey];
        }

        //public IQueryable<TEntity> Include<TEntity>(
        //    params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        //{
        //    IQueryable<TEntity> query = context.Set<TEntity>();

        //    foreach (var include in includes)
        //    {
        //        query = query.Include(include);
        //    }

        //    return query;
        //}
        //public async Task<TEntity> Include<TEntity>(int id,
        //    params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
        //{
        //    var query = context.Set<TEntity>().AsQueryable();
        //    foreach (var include in includes)
        //    {
        //        query = query.Include(include);
        //    }
        //    return await query.FirstOrDefaultAsync(e => e.Id == id);
        //}
		//public List<T> SelectItem<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
		//{
		//	IQueryable<T> query = context.Set<T>();

		//	if (includes != null)
		//	{
		//		foreach (var include in includes)
		//		{
		//			query = query.Include(include);
		//		}
		//	}

		//	if (predicate != null)
		//	{
		//		query = query.Where(predicate);
		//	}

		//	return query.ToList();
		//}

  //      public Task<List<T>> SelectItemAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
  //      {
  //          IQueryable<T> query = context.Set<T>();

  //          if (includes != null)
  //          {
  //              foreach (var include in includes)
  //              {
  //                  query = query.Include(include);
  //              }
  //          }

  //          if (predicate != null)
  //          {
  //              query = query.Where(predicate);
  //          }

  //          return query.ToListAsync();
  //      }
	}
}


