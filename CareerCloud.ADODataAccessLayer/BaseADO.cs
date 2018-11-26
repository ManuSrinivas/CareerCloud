using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
	public abstract class BaseADO
	{
		protected string connString;
		public BaseADO()
		{
			//connString = @"Data Source=LAPTOP-542KT1B3\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
			connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
		}
	}
}
