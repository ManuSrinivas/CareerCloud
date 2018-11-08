﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos
{
	[Table("Applicant_Profiles")]
	class ApplicantProfilePoco : IPoco
	{
		[Key]
		public Guid Id { get; set; }

		public Guid Login { get; set; }

		[Column("Current_Salary")]
		public Decimal? CurrentSalary { get; set; }

		[Column("Current_Rate")]
		public Decimal? CurrentRate { get; set; }

		public string Currency { get; set; }

		[Column("Country_Code")]
		public string Country { get; set; }

		[Column("State_Province_Code")]
		public string Province { get; set; }

		[Column("Street_Address")]
		public String Street { get; set; }

		[Column("City_Town")]
		public string City { get; set; }

		[Column("Zip_Postal_Code")]
		public String PostalCode { get; set; }

		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

	}
}
