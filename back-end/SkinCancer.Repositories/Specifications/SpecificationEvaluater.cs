using Microsoft.EntityFrameworkCore;
using SkinCancer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications
{
	public class SpecificationEvaluater<TEntity> where TEntity : BaseEntity
	{
		// function to Generate Query

		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,// base query
													Ispecification<TEntity> specs)// Exstra specifications
		{
			//q1
			var query = inputQuery;

			//q1 + where
			if (specs is not null)
				query = query.Where(specs.Criteria);
			if (specs.OrderBy is not null)
				query = query.OrderBy(specs.OrderBy);
			if (specs.OrderByDescending is not null)
				query = query.OrderByDescending(specs.OrderByDescending);

			// for Includes List
			// q1 + where + .include().include().include()...   <-include list
			query = specs.Includes.Aggregate(query
			//product           include()      => context.products.include() 
			, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
			return query;

		}
	}

}
