using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications.Clinic
{
	public class ClinicSpecifications
	{
		public int Id { get; set; }
		public int MinPrice { get; set; }
		public int MaxPrice { get; set; }
		public string Sort { get; set; }
	}
}
