using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
	[DataContract]
	[Table("System_Language_Codes")]
	public class SystemLanguageCodePoco
	{
		[Key]
		[DataMember]
		public string LanguageID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		[Column("Native_Name")]
		public string NativeName { get; set; }

		public virtual ICollection<CompanyDescriptionPoco> CompanyDescription { get; set; }
	}
}
