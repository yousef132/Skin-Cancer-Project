﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications
{
	public class BaseSpecification<T> : Ispecification<T>
	{

		public Expression<Func<T, bool>> Criteria { get; }

		public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

		public Expression<Func<T, object>> OrderBy { get; private set; }

		public BaseSpecification(Expression<Func<T, bool>> criteria)
		{
			Criteria = criteria;
		}

		public Expression<Func<T, object>> OrderByDescending { get; private set; }

		public int Take { get; private set; }

		public int Skip { get; private set; }

		public bool IsPaginated { get; private set; }

		protected void AddInclude(Expression<Func<T, object>> include)
			=> Includes.Add(include);


		protected void AddOrderBy(Expression<Func<T, object>> orderBy)
			=> this.OrderBy = orderBy;
		protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescending)
			=> this.OrderByDescending = OrderByDescending;
	
	}
}
