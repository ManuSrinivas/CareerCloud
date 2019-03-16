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
	[Table("Security_Roles")]
	public class SecurityRolePoco : IPoco
	{
		[DataMember]
		[Key]
		public Guid Id { get; set; }

		[DataMember]
		public string Role { get; set; }

		[DataMember]
		[Column("Is_Inactive")]
		public bool IsInactive { get; set; }

		public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
	}
}
