using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Repositories.Specifications.Schedule
{
	public class ScheduleWithSpecifications : BaseSpecification<SkinCancer.Entities.Models.Schedule>
	{
		public ScheduleWithSpecifications(int clinicId)
			: base(s => s.ClinicId == clinicId && s.IsBooked)
		{
			AddInclude(s => s.Clinic);
			AddInclude(s => s.Patient);

		}
		public ScheduleWithSpecifications(string patientId)
			: base(s => s.PatientId == patientId)
		{
			AddInclude(s => s.Clinic);
			AddInclude(s => s.Patient);

		}
	}
}