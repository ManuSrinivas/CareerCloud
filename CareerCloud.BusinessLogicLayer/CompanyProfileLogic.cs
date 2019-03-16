using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
	{
		public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
		{
		}

		public override void Add(CompanyProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override void Update(CompanyProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyProfilePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (CompanyProfilePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.ContactPhone))
				{
					exceptions.Add(new ValidationException(601, $"{poco.Id} must coresspond to a valid phone number"));
				}
				else 
				{
					string[] phonenum = poco.ContactPhone.Split('-');
					if (phonenum.Length < 3)
					{
						exceptions.Add(new ValidationException(601, $"{poco.Id} must coresspond to a valid phone number"));
					}
					else
					{
						if (phonenum[0].Length < 3)
						{
							exceptions.Add(new ValidationException(601, $"{poco.Id} must coresspond to a valid phone number"));
						}
						else if (phonenum[1].Length < 3)
						{
							exceptions.Add(new ValidationException(601, $"{poco.Id} must coresspond to a valid phone number"));
						}
						else if (phonenum[2].Length < 4)
						{
							exceptions.Add(new ValidationException(601, $"{poco.Id} must coresspond to a valid phone number"));
						}
					}
				}

				if (string.IsNullOrEmpty(poco.CompanyWebsite))
				{
					exceptions.Add(new ValidationException(600, $"Valid websites must end with the following extentions - .ca, .com, .biz"));
				}
				else if (!Regex.IsMatch(poco.CompanyWebsite, @".*\.(ca|com|biz)", RegexOptions.IgnoreCase))
				{
					exceptions.Add(new ValidationException(600, $"Valid websites must end with the following extentions - .ca, .com, .biz"));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
