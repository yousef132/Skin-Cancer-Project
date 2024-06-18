﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications
{
	public interface Ispecification<T>
	{
		Expression<Func<T, bool>> Criteria { get; } // where

		List<Expression<Func<T, object>>> Includes { get; }//Include

		Expression<Func<T, object>> OrderBy { get; }
		Expression<Func<T, object>> OrderByDescending { get; }
	}
}
