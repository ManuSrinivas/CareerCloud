﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
	{
		public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
		{ 
		}

		public override void Add(ApplicantEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override void Update(ApplicantEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(ApplicantEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (ApplicantEducationPoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.Major) || poco.Major.Length < 3)
				{
					exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Major} cannot be empty"));
				}
				else if (poco.Major.Length < 3)
				{
					exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Major} can't be less than 3 characters"));
				}

				if (poco.StartDate > DateTime.Now)
				{
					exceptions.Add(new ValidationException(108, $"Date time of {poco.StartDate} can't be greater than today"));
				}

				if (poco.CompletionDate < poco.StartDate)
				{
					exceptions.Add(new ValidationException(109, $"Completion date of {poco.CompletionDate} can't be earlier than start date {poco.StartDate}"));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
