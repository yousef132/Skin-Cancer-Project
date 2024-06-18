using SkinCancer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications.Detection
{
	public class DetectionWithSpecifications : BaseSpecification<DetectionData>
	{
		public DetectionWithSpecifications(int id)
			: base(d => d.Id == id)
		{

		}
	}
}