using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
	[ServiceContract]
	interface ISystem
	{
		[OperationContract]
		void AddSystemCountryCode(SystemCountryCodePoco[] items);

		[OperationContract]
		List<SystemCountryCodePoco> GetAllSystemCountryCode();

		[OperationContract]
		SystemCountryCodePoco GetSingleSystemCountryCode(string code);

		[OperationContract]
		void RemoveSystemCountryCode(SystemCountryCodePoco[] items);

		[OperationContract]
		void UpdateSystemCountryCode(SystemCountryCodePoco[] items);

		[OperationContract]
		void AddSystemLanguageCode(SystemLanguageCodePoco[] items);

		[OperationContract]
		List<SystemLanguageCodePoco> GetAllSystemLanguageCode();

		[OperationContract]
		SystemLanguageCodePoco GetSingleSystemLanguageCode(string LanguageId);

		[OperationContract]
		void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items);

		[OperationContract]
		void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items);
	}
}
