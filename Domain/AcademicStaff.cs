using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class AcademicStaff  
	{
		//[Key] me bo lidhjen me user
		//me i bo required
		public Guid AcademicStaffId { get; set; }

		public virtual User User { get; set; }

		public int AcademicLevelId { get; set; }
		public AcademicLevel AcademicLevel { get; set; }
	}
}
