using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
	{
		public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
		{
		}

		public override void Add(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override void Update(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyJobEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (CompanyJobEducationPoco poco in pocos)
			{
				if (poco.Major != null && poco.Major.Length < 3)
				{
					exceptions.Add(new ValidationException(200, $"Major of {poco.Id} must be atleast 2 characters long"));
				}

				if (poco.Importance < 0)
				{
					exceptions.Add(new ValidationException(201, $"Importance of {poco.Id} can't be less than 0"));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
