using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications.Clinic
{
	public class ClinicWithSpecifications : BaseSpecification<SkinCancer.Entities.Models.Clinic>
	{
		public ClinicWithSpecifications()
			: base(c => c.Price >= 0)
		{
			AddInclude(c => c.Schedules);
			AddInclude(c => c.PatientRates);
		}

		public ClinicWithSpecifications(ClinicSpecifications specs)
			: base(c =>
			((c.Price >= specs.MinPrice && c.Price <= specs.MaxPrice) || (specs.MinPrice == 0 && specs.MaxPrice == 0)) &&
			((c.Id == specs.Id))

			)
		{
			AddInclude(c => c.Schedules);
			AddInclude(c => c.PatientRates);

			// sort 
			if (!String.IsNullOrEmpty(specs.Sort))
			{
				switch (specs.Sort)
				{
					case "Rate":
						AddOrderByDescending(c => c.Rate);
						break;
					default:
						AddOrderBy(x => x.Name);
						break;
				}
			}
		}
	}
}
